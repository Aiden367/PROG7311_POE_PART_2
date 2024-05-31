using Microsoft.AspNetCore.Mvc;

namespace PROG7311_POE_PART_2.Controllers
{
    public class MarketplaceController : Controller
    {
        /// <summary>
        /// IAction Result to display the Marketplace view
        /// </summary>
        /// <returns></returns>
        public IActionResult MarketplaceView()
        {
            return View("MarketplaceView");
        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//