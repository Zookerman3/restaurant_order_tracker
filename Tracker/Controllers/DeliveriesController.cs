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
                            .Select(i => new
                            {
                                MeatOrderId = i.MeatOrderId,
                                MeatandRestaurant = i.MeatAndRestaurant
                            }).ToList();
            meatOrder.Insert(0, new { MeatOrderId = 0, MeatandRestaurant = "" });
            ViewBag.MeatOrderId = new SelectList(meatOrder, "MeatOrderId", "MeatandRestaurant");

            var vegOrder = _db.VegetableOrders
                                        .Select(i => new
                                        {
                                            VegetableOrderId = i.VegetableOrderId,
                                            VegandRestaurant = i.VegAndRestaurant
                                        }).ToList();
            vegOrder.Insert(0, new { VegetableOrderId = 0, VegandRestaurant = "" });
            ViewBag.VegetableOrderId = new SelectList(vegOrder, "VegetableOrderId", "VegandRestaurant");

            var alcOrder = _db.AlcoholOrders
                                        .Select(i => new
                                        {
                                            AlcoholOrderId = i.AlcoholOrderId,
                                            AlcandRestaurant = i.AlcAndRestaurant
                                        }).ToList();
            alcOrder.Insert(0, new { AlcoholOrderId = 0, AlcandRestaurant = "" });
            ViewBag.AlcoholOrderId = new SelectList(alcOrder, "AlcoholOrderId", "AlcandRestaurant");
            return View();

        }

        [HttpPost]
        public ActionResult Create(int meatOrderId, int VegetableOrderId, int AlcoholOrderId, string DeliveryName)
        {
#nullable enable
            Delivery? joinEntity = _db.Deliveries.FirstOrDefault(join => (join.MeatOrderId == meatOrderId && join.VegetableOrderId == VegetableOrderId && join.AlcoholOrderId == AlcoholOrderId));
#nullable disable
            if (joinEntity == null && meatOrderId != 0 && VegetableOrderId != 0 && AlcoholOrderId != 0)
            {
                _db.Deliveries.Add(new Delivery() { MeatOrderId = meatOrderId, VegetableOrderId = VegetableOrderId, AlcoholOrderId = AlcoholOrderId, DeliveryName = DeliveryName });
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Deliveries");
        }

    }
}
