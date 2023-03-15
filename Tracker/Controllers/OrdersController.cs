using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}