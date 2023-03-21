using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class VegetableOrdersController : Controller
    {
        private readonly TrackerContext _db;

        public VegetableOrdersController(TrackerContext db)
        {
            _db = db;
        }

        public ActionResult Create(int id)
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
            ViewBag.VegetableId = new SelectList(_db.Vegetables, "VegetableId", "VegetableType");
            return View();
        }

        [HttpPost]
        public ActionResult Create(int restaurantId, int vegetableId)
        {
#nullable enable
            VegetableOrder? joinEntity = _db.VegetableOrders.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.VegetableId == vegetableId));
#nullable disable
            if (joinEntity == null && vegetableId != 0)
            {
                _db.VegetableOrders.Add(new VegetableOrder() { RestaurantId = restaurantId, VegetableId = vegetableId });
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "RestaurantOrders");
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