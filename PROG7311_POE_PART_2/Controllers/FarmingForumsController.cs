using Microsoft.AspNetCore.Mvc;

namespace PROG7311_POE_PART_2.Controllers
{
    public class FarmingForumsController : Controller
    {
        /// <summary>
        /// IAction Result to disply the farming forums view
        /// </summary>
        /// <returns></returns>
        public IActionResult FarmingForumsView()
        {
            return View("FarmingForumsView");
        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//