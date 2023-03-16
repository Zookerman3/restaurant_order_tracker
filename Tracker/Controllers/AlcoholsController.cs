using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class AlcoholsController : Controller
    {

        private readonly TrackerContext _db;

        public AlcoholsController(TrackerContext db)
        {
            _db = db;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Alcohol alcohol)
        {
            _db.Alcohols.Add(alcohol);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
        }
        public ActionResult Details(int id)
        {
            Alcohol thisAlcohol = _db.Alcohols
                                    .FirstOrDefault(alcohol => alcohol.AlcoholId == id);
            return View(thisAlcohol);
        }

        public ActionResult Edit(int id)
        {
            Alcohol thisAlcohol = _db.Alcohols.FirstOrDefault(alcohol => alcohol.AlcoholId == id);
            return View(thisAlcohol);
        }

        [HttpPost]
        public ActionResult Edit(Alcohol alcohol)
        {
            _db.Alcohols.Update(alcohol);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
        }

        public ActionResult Delete(int id)
        {
            Alcohol thisAlcohol = _db.Alcohols.FirstOrDefault(alcohol => alcohol.AlcoholId == id);
            return View(thisAlcohol);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Alcohol thisAlcohol = _db.Alcohols.FirstOrDefault(alcohol => alcohol.AlcoholId == id);
            _db.Alcohols.Remove(thisAlcohol);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
        }
    }
}