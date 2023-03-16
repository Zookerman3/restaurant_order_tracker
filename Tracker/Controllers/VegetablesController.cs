using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;


namespace Tracker.Controllers
{
    public class VegetablesController : Controller
    {

        private readonly TrackerContext _db;

        public VegetablesController(TrackerContext db)
        {
            _db = db;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vegetable vegetable)
        {
            _db.Vegetables.Add(vegetable);
            _db.SaveChanges();
            return RedirectToAction("Index", "Orders");
        }
        public ActionResult Details(int id)
        {
            Vegetable thisVegetable = _db.Vegetables
                                    .FirstOrDefault(vegetable => vegetable.VegetableId == id);
            return View(thisVegetable);
        }

        public ActionResult Edit(int id)
        {
            Vegetable thisVegetable = _db.Vegetables.FirstOrDefault(vegetable => vegetable.VegetableId == id);
            return View(thisVegetable);
        }

        [HttpPost]
        public ActionResult Edit(Vegetable vegetable)
        {
            _db.Vegetables.Update(vegetable);
            _db.SaveChanges();
            return RedirectToAction("Index", "Orders");
        }

        public ActionResult Delete(int id)
        {
            Vegetable thisVegetable = _db.Vegetables.FirstOrDefault(vegetable => vegetable.VegetableId == id);
            return View(thisVegetable);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vegetable thisVegetable = _db.Vegetables.FirstOrDefault(vegetable => vegetable.VegetableId == id);
            _db.Vegetables.Remove(thisVegetable);
            _db.SaveChanges();
            return RedirectToAction("Index", "Orders");
        }
    }
}