using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class RestaurantOrdersController : Controller
    {
        private readonly TrackerContext _db;

        public RestaurantOrdersController(TrackerContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            MeatOrder[] meatOrder = _db.MeatOrders.Include(meatOrder => meatOrder.Meat)
                                                    .Include(thisRestaurant => thisRestaurant.Restaurant)
                                                    .ToArray();
            VegetableOrder[] vegOrder = _db.VegetableOrders.Include(vegOrder => vegOrder.Vegetable)
                                                            .Include(thisRestaurant => thisRestaurant.Restaurant).ToArray();
            AlcoholOrder[] alcOrder = _db.AlcoholOrders.Include(meatOrder => meatOrder.Alcohol)
                                                        .Include(thisRestaurant => thisRestaurant.Restaurant)
                                                        .ToArray();
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            model.Add("meatOrder", meatOrder);
            model.Add("vegOrder", vegOrder);
            model.Add("alcOrder", alcOrder);

            return View(model);
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
