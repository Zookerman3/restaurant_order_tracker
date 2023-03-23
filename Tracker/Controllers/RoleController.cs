using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private TrackerContext _db;
        private UserManager<ApplicationUser> _userManage;
        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userManager, TrackerContext db)


        {
            roleManager = roleMgr;
           _userManage = userManager;
           _db = db;
        }

        public ViewResult Index() => View(roleManager.Roles);

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}