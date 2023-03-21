using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tracker.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly TrackerContext _db;

        public DeliveriesController(TrackerContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            Delivery[] delivery = _db.Deliveries.Include(delivery => delivery.JoinMeatOrderEntities)
                                                .ThenInclude(meatOrder => meatOrder.Meat)
                                                .Include(delivery => delivery.JoinMeatOrderEntities)
                                                .ThenInclude(meatOrder => meatOrder.Restaurant)
                                                .Include(delivery => delivery.JoinVegetableOrderEntities)
                                                .ThenInclude(vegOrder => vegOrder.Vegetable)
                                                .Include(delivery => delivery.JoinVegetableOrderEntities)
                                                .ThenInclude(vegOrder => vegOrder.Restaurant)
                                                .Include(delivery => delivery.JoinAlcoholEntities)
                                                .ThenInclude(alcOrder => alcOrder.Alcohol)
                                                .Include(delivery => delivery.JoinAlcoholEntities)
                                                .ThenInclude(alcOrder => alcOrder.Restaurant).ToArray();
            return View(delivery);
        }
        public ActionResult Create()
        {
            var meatOrder = _db.MeatOrders
                            .Select (i => new
                            {
                                MeatOrderId= i.MeatOrderId,
                                MeatType= i.Meat.MeatType
                            }).ToList();
            ViewBag.MeatOrderId = new SelectList(meatOrder, "MeatOrderId", "MeatType");
            // ViewBag.VegetableOrderId = new SelectList(_db.VegetableOrders, "VegetableOrderId", "VegetableType");
            // ViewBag.AlcoholOrderId = new SelectList(_db.AlcoholOrders, "AlcoholOrderId", "AlcoholType");
            return View();

        }

        [HttpPost]
        public ActionResult Create(int meatOrderId, int vegOrderId, int alcOrderId)
        {
#nullable enable
            Delivery? joinEntity = _db.Deliveries.FirstOrDefault(join => (join.MeatOrderId == meatOrderId && join.VegetableOrderId == vegOrderId && join.AlcoholOrderId == alcOrderId));
#nullable disable
            if (joinEntity == null && meatOrderId != 0 && vegOrderId != 0 && alcOrderId != 0)
            {
                _db.Deliveries.Add(new Delivery() { MeatOrderId = meatOrderId, VegetableOrderId = vegOrderId, AlcoholOrderId = alcOrderId });
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Deliveries");
        }

    }
}
