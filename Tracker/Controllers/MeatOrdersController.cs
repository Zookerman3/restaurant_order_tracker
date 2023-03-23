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
        public async Task<ActionResult> Create(int restaurantId, int meatId)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else{
            #nullable enable
                MeatOrder? joinEntity = _db.MeatOrders.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.MeatId == meatId));
#nullable disable
                if  (joinEntity == null && meatId != 0)
                
                    // If no matching MeatOrder exists, create a new one and set its properties
                    joinEntity = new MeatOrder();
                    joinEntity.RestaurantId = restaurantId;
                    joinEntity.MeatId = meatId;
                    string meatAndRestaurant = $"{_db.Restaurants.Find(restaurantId).Name} - {_db.Meats.Find(meatId).MeatType}";
                    joinEntity.MeatAndRestaurant = meatAndRestaurant;

                    // Set the current user as the User of the new MeatOrder
                    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
                    joinEntity.User = currentUser;

                    // Add the new MeatOrder to the database and save changes
                    _db.MeatOrders.Add(joinEntity);
                    _db.SaveChanges();
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