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
    public class OrderTemplatesController : Controller
    {
        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderTemplatesController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<ActionResult> Index()
        {
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

            if (currentUser != null)
            {
                
                Meat[] meat = _db.Meats
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToArray();
                Vegetable[] vegs = _db.Vegetables
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToArray();
                Alcohol[] alcs = _db.Alcohols
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToArray();

                model.Add("meats", meat);
                model.Add("vegetables", vegs);
                model.Add("alcohols", alcs);
            }
            {

                return View(model);
            }
        }
    }
}