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
    public class RestaurantsController : Controller
    {
        private readonly TrackerContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantsController(UserManager<ApplicationUser> userManager, TrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            List<Restaurant> usersRestaurants = _db.Restaurants
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToList();
            return View(usersRestaurants);
        }


        // public ActionResult Index()
        // {
        //     List<Restaurant> model = _db.Restaurants.ToList();
        //     return View(model);
        // }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
                restaurant.User = currentUser;
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }



        // [HttpPost]
        // public ActionResult Create(Restaurant restaurant)
        // {
        //     _db.Restaurants.Add(restaurant);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }

        public ActionResult Details(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants
                                    .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            return View(thisRestaurant);
        }

        public ActionResult Edit(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            return View(thisRestaurant);
        }

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            _db.Restaurants.Update(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            return View(thisRestaurant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            _db.Restaurants.Remove(thisRestaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
