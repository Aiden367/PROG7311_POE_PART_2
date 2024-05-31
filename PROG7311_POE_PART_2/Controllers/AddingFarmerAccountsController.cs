using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.DbContexts;
using PROG7311_POE_PART_2.Services;
using PROG7311_POE_PART_2.ViewModel;
using System.Diagnostics;

namespace PROG7311_POE_PART_2.Controllers
{
    public class AddingFarmerAccountsController : Controller
    {
        /// <summary>
        /// instansiating UserService class
        /// </summary>
        private readonly UserService _userService;

        /// <summary>
        /// Instansiating PROGPOECOntext class
        /// </summary>
        private readonly PROGPOEContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="dbContext"></param>
        public AddingFarmerAccountsController(UserService userService, PROGPOEContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Task that populates the username and role combo boxes 
        /// </summary>
        /// <returns></returns>
        public async Task <IActionResult> AddingFarmerAccountsView()
        {
            PopulateUsernamesComboBox();
            var viewModel = PopulateUserRolesComboBox();

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
                return View("AddingFarmerAccountsView", viewModel);
            }
            else
            {
                viewModel = new AddFarmerAccountsViewModel();
                return View("AddingFarmerAccountsView", viewModel);
            }
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that changes the users role in the database to Farmer 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AssignRole(AddFarmerAccountsViewModel viewModel)
        {
            var result = await _userService.AddRoleToUserAsync(viewModel.selectedUsername, viewModel.selectedUserRole);
            if (result)
            {
                return Ok(new { message = "Role assigned successfully" });
            }
            return BadRequest(new { message = "Failed to assign role" });
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// task that removes the users role
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RemoveRole(int userId, int roleId)
        {
            var result = await _userService.RemoveRoleFromUserAsync(userId, roleId);
            if (result)
            {
                return Ok(new { message = "Role removed successfully" });
            }
            return BadRequest(new { message = "Failed to remove role" });
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method to get the users role
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            var roles = await _userService.GetUserRolesAsync(userId);
            return Ok(roles);
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that retrieves all of the users roles and populates the userroles combo box
        /// </summary>
        /// <returns></returns>
        public AddFarmerAccountsViewModel PopulateUserRolesComboBox()
        {
            try
            {
                // Query to get distinct farmers' names from the ProductDetailsTable
                var allUserRoles = _dbContext.Roles
                                             .Select(p => p.RoleName) // Assuming FarmerName is the column name
                                             .Distinct()
                                             .ToList();
                var viewModel = new AddFarmerAccountsViewModel
                {
                    userRoleList = allUserRoles
                };
                return viewModel;
                Debug.WriteLine("Could not find role");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Error Line 86 AddingCourseController");
            }
            return new AddFarmerAccountsViewModel();
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that collects all of the usernames from the database and populates the username combobox
        /// </summary>
        /// <returns></returns>
        public AddFarmerAccountsViewModel PopulateUsernamesComboBox()
        {
            try
            {
                // Query to get distinct farmers' names from the ProductDetailsTable
                var usernames = _dbContext.User
                                             .Select(p => p.Usernames) // Assuming FarmerName is the column name
                                             .Distinct()
                                             .ToList();
                var viewModel = new AddFarmerAccountsViewModel
                {
                    usernameList = usernames
                };
                return viewModel;
                Debug.WriteLine("Could not find user");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Error Line 141");
            }
            return new AddFarmerAccountsViewModel();
        }
        //---------------------------------------------------------------//
    }

}
//----------------------------------------------------------END OF FILE---------------------------------------------//