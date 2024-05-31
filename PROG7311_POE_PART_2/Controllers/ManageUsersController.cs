using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.DbContexts;
using PROG7311_POE_PART_2.Models;
using PROG7311_POE_PART_2.ViewModel;
using System.Diagnostics;

namespace PROG7311_POE_PART_2.Controllers
{
    public class ManageUsersController : Controller
    {

        /// <summary>
        /// Instansiating the dbContext
        /// </summary>
        private readonly PROGPOEContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public ManageUsersController(PROGPOEContext dbContext)
        {
            _dbContext = dbContext;
        }

        //---------------------------------------------------------------//
        /// <summary>
        /// IActionResult to load the VIewmodel that contains the SemesterModel and the ModuleModel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ManageUsersView()
        {
            PopulateCategoryComboBox();
            PopulateUserRolesComboBox();
            PopulateUsernamesComboBox();
            var viewModel = PopulateFarmersNameComboBox();
            // Query to get all distinct farmer names from the Product table
            viewModel.productCategoryList = await _dbContext.Product
                .Select(p => p.ProductCategory)
                .Distinct()
                .ToListAsync();
            viewModel.usernameList = await _dbContext.User
                .Select(p => p.Usernames)
                .Distinct()
                .ToListAsync();
            viewModel.userRoleList = await _dbContext.Roles
                .Select(p => p.RoleName)
                .Distinct()
                .ToListAsync();
            if (viewModel != null)
            {
                return View ("ManageUsersView",viewModel);
            }
            else
            {
                viewModel = new ManageUsersViewModel();
                return View("ManageUsersView", viewModel);
            }
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that populates the Farmers combobox with all of the farmers names 
        /// </summary>
        /// <returns></returns>
        public ManageUsersViewModel PopulateFarmersNameComboBox()
        {
            try
            {
                // Query to get distinct farmers' names from the ProductDetailsTable
                var farmersNames = _dbContext.Product
                                             .Select(p => p.FarmerName) // Assuming FarmerName is the column name
                                             .Distinct()
                                             .ToList();
                var viewModel = new ManageUsersViewModel
                    {
                    farmerNamesList = farmersNames
                    };
                    return viewModel;
                Debug.WriteLine("Could not find semester");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Error Line 86 AddingCourseController");
            }
            return new ManageUsersViewModel();
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that populates the user roles combobox with all of the users roles
        /// </summary>
        /// <returns></returns>
        public ManageUsersViewModel PopulateUserRolesComboBox()
        {
            try
            {
                // Query to get distinct farmers' names from the ProductDetailsTable
                var userRoles = _dbContext.Roles
                                             .Select(p => p.RoleName) // Assuming FarmerName is the column name
                                             .Distinct()
                                             .ToList();
                var viewModel = new ManageUsersViewModel
                {
                    userRoleList = userRoles
                };
                return viewModel;
                Debug.WriteLine("Could not find user role");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Error Line 86 AddingCourseController");
            }
            return new ManageUsersViewModel();
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that populates the usernames combobox with all of the usernames saved in the database
        /// </summary>
        /// <returns></returns>
        public ManageUsersViewModel PopulateUsernamesComboBox()
        {
            try
            {
                // Query to get distinct farmers' names from the ProductDetailsTable
                var usernames = _dbContext.User
                                             .Select(p => p.Usernames) // Assuming FarmerName is the column name
                                             .Distinct()
                                             .ToList();
                var viewModel = new ManageUsersViewModel
                {
                    usernameList = usernames
                };
                return viewModel;
                Debug.WriteLine("Could not find username");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Error Line 86");
            }
            return new ManageUsersViewModel();
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that populates the category combobox with categories from the database
        /// </summary>
        /// <returns></returns>
        public ManageUsersViewModel PopulateCategoryComboBox()
        {
            try
            {
                // Query to get distinct farmers' names from the ProductDetailsTable
                var categoryNames = _dbContext.Product
                                             .Select(p => p.ProductCategory) // Assuming FarmerName is the column name
                                             .Distinct()
                                             .ToList();
                var viewModel = new ManageUsersViewModel
                {
                    productCategoryList = categoryNames
                };
                return viewModel;
                Debug.WriteLine("Could not find category");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Error Line 86");
            }
            return new ManageUsersViewModel();
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that populates the farmers table with data from the database 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PopulateFarmerDetailsTable(ManageUsersViewModel viewModel)
        {
            try
            {
                string chosenFarmerName = viewModel.selectedFarmerName;
                string chosenCategory = viewModel.selectedProductCategory;
                DateTime chosenDate = viewModel.selectedDate;
                var selectedFarmer = await _dbContext.Product.FirstOrDefaultAsync(s => s.FarmerName == chosenFarmerName);
                if (selectedFarmer != null)
                {
                    // Query to get products that match the selected filters
                    var products = await _dbContext.Product
                                                   .Where(p => p.FarmerName == chosenFarmerName &&
                                                               p.ProductCategory == chosenCategory &&
                                                               p.DateProductListed.Date == chosenDate.Date)
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
                    viewModel.ProductsList = products;
                    // Query to get all distinct farmer names from the Product table
                    viewModel.farmerNamesList = await _dbContext.Product
                        .Select(p => p.FarmerName)
                        .Distinct()
                        .ToListAsync();
                    // Query to get all distinct farmer names from the Product table
                    viewModel.productCategoryList = await _dbContext.Product
                        .Select(p => p.ProductCategory)
                        .Distinct()
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Line 126 DisplayModulesController");
            }
            return View("ManageUsersView", viewModel);
        }
        //---------------------------------------------------------------//
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//