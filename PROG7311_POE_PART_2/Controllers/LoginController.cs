using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.DbContexts;
using PROG7311_POE_PART_2.Models;
using PROG7311_POE_PART_2.ViewModel;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Services;

namespace PROG7311_POE_PART_2.Controllers
{
    public class LoginController : Controller
    {

        /// <summary>
        /// instansiating the dbContext
        /// </summary>
        private readonly PROGPOEContext _dbContext;

        /// <summary>
        /// Instansiation of the PasswordHasher Class
        /// </summary>
        public PasswordHasherModel hasher = new PasswordHasherModel();

        /// <summary>
        /// Variable to bind to the password textbox
        /// </summary>
        private string Password = string.Empty;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public LoginController(PROGPOEContext dbContext)
        {
            _dbContext = dbContext;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// method that display the user with the Login View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LoginView()
        {
            var userAndRoleViewModel = new UserDetailsAndRoleViewModel();
            return View(userAndRoleViewModel);
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// method that searches through the users table in the database and checks if the username matches with the entered username
        /// it then hashes the entered password with the salt that is connected to the found user in the database
        /// it then creates a claim that defines the users name and its role
        /// it then creates a claims identity object and this represents the identity of the user it takes the list of claims and the autherization scheme
        /// once the user is authorized it then takes them to the home page 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginView(UserDetailsAndRoleViewModel userAndRoleViewModel)
        {
            try
            {
                var enteredUsername = _dbContext.User.FirstOrDefault(u => u.Usernames == userAndRoleViewModel.UserDetails.Usernames);
                if (enteredUsername == null)
                {
                    ModelState.AddModelError("Usernames", "Username does not exist");
                    return View("LoginView", userAndRoleViewModel);
                }
                else
                {
                    if (this.hasher.VerifyPassword(userAndRoleViewModel.UserDetails.Passwords, enteredUsername.Passwords, enteredUsername.Salt))
                    {
                        UserProfileService.Username = enteredUsername.Usernames;
                        UserProfileService.SharedUserID = enteredUsername.UserID;
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        // Retrieve the user's role from the database
                        var userRole = await _dbContext.User.FirstOrDefaultAsync(ur => ur.UserID == enteredUsername.UserID);
                        var roleName = userRole != null ? (await _dbContext.Roles.FindAsync(userRole.RoleID))?.RoleName : "User";
                        Debug.WriteLine("Role Name:", roleName);
                        Debug.WriteLine("User Role:", userRole);
                        var claims = new List<Claim>
                        {
                         new Claim(ClaimTypes.Name, enteredUsername.Usernames),
                         new Claim(ClaimTypes.Role, roleName ?? "User"), // Default to "User" if roleName is null
                         new Claim("UserID", enteredUsername.UserID.ToString())
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true,
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToAction("FarmingHubView", "FarmingHub");
                    }
                    else
                    {
                        Debug.WriteLine("Error logging in");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex}");
            }
            return RedirectToAction("LoginView", "Login");
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// If the user selects the Create account button it redirects the user to the register page
        /// </summary>
        /// <returns></returns>
        public IActionResult RegisterView()
        {
            return RedirectToAction("RegisterView", "Register");
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method to check if the username is valid 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsUserValid(string username, string password)
        {
            try
            {
                if (_dbContext.User.Any(m => m.Usernames.Equals(username) && m.Passwords.Equals(password)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.Write("LoginController Line 118");
                return false;
            }
        }
        //---------------------------------------------------------------//
    }
}
//-----------------------------------------------------------END OF FILE------------------------------------------------------//