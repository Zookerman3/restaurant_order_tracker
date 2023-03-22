using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Tracker.Controllers
{
    [Authorize]
    public class VegetablesController : Controller
    {

        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public VegetablesController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Vegetable vegetable)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            vegetable.User = currentUser;
            _db.Vegetables.Add(vegetable);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
            }
           
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
            return RedirectToAction("Index", "OrderTemplates");
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
            return RedirectToAction("Index", "OrderTemplates");
        }
    }
}