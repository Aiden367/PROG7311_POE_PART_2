using Microsoft.AspNetCore.Mvc;

namespace PROG7311_POE_PART_2.Controllers
{
    public class TrainingResourcesController : Controller
    {
        /// <summary>
        /// IActionResult to display the training resources view
        /// </summary>
        /// <returns></returns>
        public IActionResult TrainingResourcesView()
        {
            return View("TrainingResourcesView");
        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//