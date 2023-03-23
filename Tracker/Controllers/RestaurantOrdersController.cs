using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Tracker.Controllers
{
    [Authorize]
    public class RestaurantOrdersController : Controller
    {
        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantOrdersController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<ActionResult> Index()
        {
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            if (currentUser != null)
            {

                MeatOrder[] meatOrder = _db.MeatOrders.Where(entry => entry.User.Id == currentUser.Id)
                                                        .Include(meatOrder => meatOrder.Meat)
                                                        .Include(thisRestaurant => thisRestaurant.Restaurant)
                                                        .ToArray();
                VegetableOrder[] vegOrder = _db.VegetableOrders.Where(entry => entry.User.Id == currentUser.Id)
                                                                .Include(vegOrder => vegOrder.Vegetable)
                                                                .Include(thisRestaurant => thisRestaurant.Restaurant)
                                                                .ToArray();
                AlcoholOrder[] alcOrder = _db.AlcoholOrders.Where(entry => entry.User.Id == currentUser.Id)
                                                            .Include(meatOrder => meatOrder.Alcohol)
                                                            .Include(thisRestaurant => thisRestaurant.Restaurant)
                                                            .ToArray();
                model.Add("meatOrder", meatOrder);
                model.Add("vegOrder", vegOrder);
                model.Add("alcOrder", alcOrder);
 }
            {

                return View(model);
            }
            }


            public ActionResult Create(int id)
            {
                ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
                ViewBag.MeatId = new SelectList(_db.Meats, "MeatId", "MeatType");
                return View();

            }

            [HttpPost]
            public ActionResult Create(int restaurantId, int meatId)
            {
#nullable enable
                MeatOrder? joinEntity = _db.MeatOrders.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.MeatId == meatId));
#nullable disable
                if (joinEntity == null && meatId != 0)
                {
                    _db.MeatOrders.Add(new MeatOrder() { RestaurantId = restaurantId, MeatId = meatId });
                    _db.SaveChanges();
                }
                return RedirectToAction("Index", "RestaurantOrders");
            }
        }
    }
