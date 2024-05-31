using Microsoft.AspNetCore.Mvc;

namespace PROG7311_POE_PART_2.Controllers
{
    public class FarmingHubController : Controller
    {
        /// <summary>
        /// IAction Result to display the farming hub view
        /// </summary>
        /// <returns></returns>
        public IActionResult FarmingHubView()
        {
            return View("FarmingHubView");
        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//