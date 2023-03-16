using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class OrdersController : Controller
    {
        private readonly TrackerContext _db;

        public OrdersController(TrackerContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            Meat[] meats = _db.Meats.ToArray();
            Vegetable[] vegs = _db.Vegetables.ToArray();
            Alcohol[] alcs = _db.Alcohols.ToArray();
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            model.Add("meats", meats);
            model.Add("vegetables", vegs);
            model.Add("alcohols", alcs);

            return View(model);
        }
    }
}