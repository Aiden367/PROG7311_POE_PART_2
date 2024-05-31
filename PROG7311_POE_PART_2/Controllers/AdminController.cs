using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.Models;
using PROG7311_POE_PART_2.Services;
using PROG7311_POE_PART_2.ViewModel;
using System.Diagnostics;

namespace PROG7311_POE_PART_2.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// Instansiating user service class
        /// </summary>
        private readonly UserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        //---------------------------------------------------------------//
        /// <summary>
        /// IActionResult that populates the AdminView page with data
        /// </summary>
        /// <returns></returns>
        public IActionResult AdminView()
        {
            var assignRoleViewModel = new AssignRoleViewModel();
            return View("AdminView",assignRoleViewModel);
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// IActionResult that assigns the role to the user 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel viewModel)
        {
            var result = await _userService.AddRoleToUserAsync(viewModel.Users.Usernames, viewModel.UserRoles.Role.RoleName);
            if (result)
            {
                return Ok(new { message = "Role assigned successfully" });
            }
            return BadRequest(new { message = "Failed to assign role" });
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// IActionResult that removes the role from the user
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
        /// IActionResult that gets the users roles
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
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//