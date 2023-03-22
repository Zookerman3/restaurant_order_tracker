using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class MeatOrdersController : Controller
    {
        private readonly TrackerContext _db;

        public MeatOrdersController(TrackerContext db)
        {
            _db = db;
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
                string meatAndRestaurant = $"{_db.Restaurants.Find(restaurantId).Name} - {_db.Meats.Find(meatId).MeatType}";
                _db.MeatOrders.Add(new MeatOrder() { RestaurantId = restaurantId, MeatId = meatId, MeatAndRestaurant = meatAndRestaurant});
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "RestaurantOrders");
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