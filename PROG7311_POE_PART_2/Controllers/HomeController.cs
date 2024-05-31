using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.Models;
using System.Diagnostics;

namespace PROG7311_POE_PART_2.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Ilogger variable form home controller
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// IActionResult index 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// IActionResult for Privacy page
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//