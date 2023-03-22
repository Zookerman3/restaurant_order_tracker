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
    public class AlcoholsController : Controller
    {

        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public AlcoholsController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Alcohol alcohol)
        {
              if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
                alcohol.User = currentUser;
            _db.Alcohols.Add(alcohol);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
            }
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