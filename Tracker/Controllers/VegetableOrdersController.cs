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
    public class VegetableOrdersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TrackerContext _db;

        public VegetableOrdersController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Create(int id)
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
            ViewBag.VegetableId = new SelectList(_db.Vegetables, "VegetableId", "VegetableType");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(int restaurantId, int vegetableId, VegetableOrder vegetableOrder)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
#nullable enable
            VegetableOrder? joinEntity = _db.VegetableOrders.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.VegetableId == vegetableId));
#nullable disable
            if (joinEntity == null && vegetableId != 0)
            {
                 string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

                vegetableOrder.User = currentUser;
                string vegAndRestaurant = $"{_db.Restaurants.Find(restaurantId).Name} - {_db.Vegetables.Find(vegetableId).VegetableType}";
                _db.VegetableOrders.Add(new VegetableOrder() { RestaurantId = restaurantId, VegetableId = vegetableId, VegAndRestaurant = vegAndRestaurant });
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "RestaurantOrders");
            }
        }

        public ActionResult Delete(int id)
        {
            VegetableOrder thisVegetableOrder = _db.VegetableOrders
            .Include(vegetableOrder => vegetableOrder.Vegetable)
            .FirstOrDefault(vegetableOrder => vegetableOrder.VegetableOrderId == id);
            return View(thisVegetableOrder);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            VegetableOrder thisVegetableOrder = _db.VegetableOrders.FirstOrDefault(vegetableOrder => vegetableOrder.VegetableOrderId == id);
            _db.VegetableOrders.Remove(thisVegetableOrder);
            _db.SaveChanges();
            return RedirectToAction("Index", "RestaurantOrders");
        }
    }
}