using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class AlcoholOrdersController : Controller
    {
        private readonly TrackerContext _db;

        public AlcoholOrdersController(TrackerContext db)
        {
            _db = db;
        }

        public ActionResult Create(int id)
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
            ViewBag.AlcoholId = new SelectList(_db.Alcohols, "AlcoholId", "AlcoholType");
            return View();

        }

        [HttpPost]
        public ActionResult Create(int restaurantId, int alcoholId)
        {
#nullable enable
            AlcoholOrder? joinEntity = _db.AlcoholOrders.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.AlcoholId == alcoholId));
#nullable disable
            if (joinEntity == null && alcoholId != 0)
            {
                _db.AlcoholOrders.Add(new AlcoholOrder() { RestaurantId = restaurantId, AlcoholId = alcoholId });
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "RestaurantOrders");
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