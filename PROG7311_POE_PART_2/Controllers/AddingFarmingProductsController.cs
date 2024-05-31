using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.Models;
using System.Diagnostics;
using PROG7311_POE_PART_2.DbContexts;
using PROG7311_POE_PART_2.Services;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.ViewModel;

namespace PROG7311_POE_PART_2.Controllers
{
    public class AddingFarmingProductsController : Controller
    {
        /// <summary>
        /// instansiating PROGPOE dbcontext
        /// </summary>
        private readonly PROGPOEContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public AddingFarmingProductsController(PROGPOEContext dbContext) 
        {
            _dbContext = dbContext;
        }

        //---------------------------------------------------------------//
        /// <summary>
        /// IAction result that populates the AddProductView
        /// </summary>
        /// <returns></returns>
        public IActionResult AddingFarmingProductsView()
        {
            var productModel = new AddProductViewModel();
            return View(productModel);
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that takes the data entered into the textboxes and saves it to the Product table in the database
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>AddingProduct(AddProductViewModel viewModel)
        {
            var farmerName = UserProfileService.Username;
            var userID = UserProfileService.SharedUserID;
            Debug.WriteLine("Username:", UserProfileService.Username);
            try
            {
                var newProduct = new AddProductModel
                {
                    UserID = userID,
                    FarmerName = farmerName,
                    ProductName = viewModel.AddProductModel.ProductName,
                    ProductDescription = viewModel.AddProductModel.ProductDescription,
                    ProductCategory = viewModel.AddProductModel.ProductCategory,
                    DateProductListed = viewModel.AddProductModel.DateProductListed
                };
                _dbContext.Product.Add(newProduct);
                await _dbContext.SaveChangesAsync();
                Debug.WriteLine("Product Added");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot add product");
                Debug.WriteLine(ex.ToString());
                Console.ReadLine();
                return Json(new { success = false });
            }
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// IAction result to populate the table with the product tables that are from the farmer that has logged in 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PopulateFarmerDetailsTableAddProduct(AddProductViewModel viewModel)
        {
            try
            {
                var selectedFarmer = await _dbContext.Product.FirstOrDefaultAsync(s => s.FarmerName == UserProfileService.Username);
                if (selectedFarmer != null)
                {
                    // Query to get products that match the selected filters
                    var products = await _dbContext.Product
                                             .Where(p => p.FarmerName == UserProfileService.Username)
                                             .Select(product => new AddProductModel
                                             {
                                                 ProductID = product.ProductID,
                                                 ProductName = product.ProductName,
                                                 ProductDescription = product.ProductDescription,
                                                 ProductCategory = product.ProductCategory,
                                                 DateProductListed = product.DateProductListed,
                                                 FarmerName = product.FarmerName
                                             })
                                             .ToListAsync();
                    // Update the view model with the retrieved products
                    viewModel.ProductsListProductModel = products;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Line 126 DisplayModulesController");
            }
            return View("AddingFarmingProductsView", viewModel);
        }
        //---------------------------------------------------------------//
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//