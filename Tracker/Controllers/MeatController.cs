using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tracker.Controllers
{
  public class MeatController : Controller
  {
    private readonly TrackerContext _db;

    public CategoriesController(TrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Meat> model = _db.Meat.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Meat meat)
    {
      _db.Meat.Add(meat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Meat thisMeat = _db.Meat
                                .Include(cat => cat.Items)
                                .ThenInclude(item => item.JoinEntities)
                                .ThenInclude(join => join.Tag)
                                .FirstOrDefault(meat => meat.MeatId == id);
      return View(thisMeat);
    }

    public ActionResult Edit(int id)
    {
      Meat thisMeat = _db.Meat.FirstOrDefault(meat => meat.MeatId == id);
      return View(thisMeat);
    }

    [HttpPost]
    public ActionResult Edit(Meat meat)
    {
      _db.Meat.Update(meat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Meat thisMeat = _db.Meat.FirstOrDefault(meat => meat.MeatId == id);
      _db.Meat.Remove(thisMeat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}