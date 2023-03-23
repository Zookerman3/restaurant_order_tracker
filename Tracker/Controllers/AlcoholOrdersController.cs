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
    public class AlcoholOrdersController : Controller
    {
        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AlcoholOrdersController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Create(int id)
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
            ViewBag.AlcoholId = new SelectList(_db.Alcohols, "AlcoholId", "AlcoholType");
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Create(int restaurantId, int alcoholId, AlcoholOrder alcoholOrder)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
#nullable enable
                AlcoholOrder? joinEntity = _db.AlcoholOrders.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.AlcoholId == alcoholId));
#nullable disable
                if (joinEntity == null && alcoholId != 0)
                {
                    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

                    alcoholOrder.User = currentUser;
                    string alcAndRestaurant = $"{_db.Restaurants.Find(restaurantId).Name} - {_db.Alcohols.Find(alcoholId).AlcoholType}";
                    _db.AlcoholOrders.Add(new AlcoholOrder() { RestaurantId = restaurantId, AlcoholId = alcoholId, AlcAndRestaurant = alcAndRestaurant });
                    _db.SaveChanges();
                }
                return RedirectToAction("Index", "RestaurantOrders");
            }
        }

        public ActionResult Delete(int id)
        {
            AlcoholOrder thisAlcoholOrder = _db.AlcoholOrders
            .Include(alcoholOrder => alcoholOrder.Alcohol)
            .FirstOrDefault(alcoholOrder => alcoholOrder.AlcoholOrderId == id);
            return View(thisAlcoholOrder);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AlcoholOrder thisAlcoholOrder = _db.AlcoholOrders.FirstOrDefault(alcoholOrder => alcoholOrder.AlcoholOrderId == id);
            _db.AlcoholOrders.Remove(thisAlcoholOrder);
            _db.SaveChanges();
            return RedirectToAction("Index", "RestaurantOrders");
        }
    }
}