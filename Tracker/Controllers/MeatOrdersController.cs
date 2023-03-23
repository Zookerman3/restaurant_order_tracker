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
    public class MeatOrdersController : Controller
    {
        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public MeatOrdersController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Create(int id)
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
            ViewBag.MeatId = new SelectList(_db.Meats, "MeatId", "MeatType");
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Create(int restaurantId, int meatId, MeatOrder meatOrder)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {

#nullable enable
                MeatOrder? joinEntity = _db.MeatOrders.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.MeatId == meatId));
#nullable disable
                if (joinEntity == null && meatId != 0)
                {
                    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

                    meatOrder.User = currentUser;
                    string meatAndRestaurant = $"{_db.Restaurants.Find(restaurantId).Name} - {_db.Meats.Find(meatId).MeatType}";
                    _db.MeatOrders.Add(new MeatOrder() { RestaurantId = restaurantId, MeatId = meatId, MeatAndRestaurant = meatAndRestaurant });
                    _db.SaveChanges();
                }
                return RedirectToAction("Index", "RestaurantOrders");
            }
        }

        public ActionResult Delete(int id)
        {
            MeatOrder thisMeatOrder = _db.MeatOrders
            .Include(meatOrder => meatOrder.Meat)
            .FirstOrDefault(meatOrder => meatOrder.MeatOrderId == id);
            return View(thisMeatOrder);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MeatOrder thisMeatOrder = _db.MeatOrders.FirstOrDefault(meatOrder => meatOrder.MeatOrderId == id);
            _db.MeatOrders.Remove(thisMeatOrder);
            _db.SaveChanges();
            return RedirectToAction("Index", "RestaurantOrders");
        }

    }
}