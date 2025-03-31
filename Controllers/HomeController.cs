using Ismetles.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ismetles.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<string>());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
