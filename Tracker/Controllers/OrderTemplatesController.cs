using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class OrderTemplatesController : Controller
    {
        private readonly TrackerContext _db;

        public OrderTemplatesController(TrackerContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            Meat[] meat = _db.Meats.ToArray();
            Vegetable[] vegs = _db.Vegetables.ToArray();
            Alcohol[] alcs = _db.Alcohols.ToArray();
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            model.Add("meats", meat);
            model.Add("vegetables", vegs);
            model.Add("alcohols", alcs);

            return View(model);
        }
    }
}