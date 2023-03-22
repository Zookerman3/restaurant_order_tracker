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
    public class MeatsController : Controller
    {

        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public MeatsController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Meat meat)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            meat.User = currentUser;
            _db.Meats.Add(meat);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
            }
        }
        public ActionResult Details(int id)
        {
            Meat thisMeat = _db.Meats
                                    .FirstOrDefault(meat => meat.MeatId == id);
            return View(thisMeat);
        }

        public ActionResult Edit(int id)
        {
            Meat thisMeat = _db.Meats.FirstOrDefault(meat => meat.MeatId == id);
            return View(thisMeat);
        }

        [HttpPost]
        public ActionResult Edit(Meat meat)
        {
            _db.Meats.Update(meat);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
        }

        public ActionResult Delete(int id)
        {
            Meat thisMeat = _db.Meats.FirstOrDefault(meat => meat.MeatId == id);
            return View(thisMeat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Meat thisMeat = _db.Meats.FirstOrDefault(meat => meat.MeatId == id);
            _db.Meats.Remove(thisMeat);
            _db.SaveChanges();
            return RedirectToAction("Index", "OrderTemplates");
        }
    }
}