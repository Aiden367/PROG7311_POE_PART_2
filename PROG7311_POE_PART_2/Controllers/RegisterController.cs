using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.DbContexts;
using PROG7311_POE_PART_2.Models;
using PROG7311_POE_PART_2.ViewModel;

namespace PROG7311_POE_PART_2.Controllers
{

    public class RegisterController : Controller
    {
        private readonly PROGPOEContext _dbContext;

        /// <summary>
        /// Variable to store the hashed password
        /// </summary>
        private string hashedPassword = string.Empty;

        /// <summary>
        /// Variable to store the salt used to hash the password
        /// </summary>
        private string salt = string.Empty;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="dbContext"></param>
        public RegisterController(PROGPOEContext dbContext)
        {
            _dbContext = dbContext;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that redirects the user to the login page if the user clicks the existing account button
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginView()
        {
            return RedirectToAction("LoginView", "Login");
        }

        //---------------------------------------------------------------//
        /// <summary>
        /// Method that displays the user with the RegisterView
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RegisterView()
        {
            var userAndRoleViewModel = new UserDetailsAndRoleViewModel();

            return View(userAndRoleViewModel);
        }

        //---------------------------------------------------------------//
        /// <summary>
        /// Method that checks if the username is already in use if it does not then
        /// it takes the inputed username and password and hashes the password
        /// and saves the username,hashed password, and the salt that was used to hash it 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterView(UserDetailsAndRoleViewModel userAndRoleViewModel)
        {
            if (checkIfUsernameIsTaken(userAndRoleViewModel.UserDetails.Usernames))
           {
                ModelState.AddModelError("Usernames", "Username already exists");
                return View("RegisterView", userAndRoleViewModel);
           }
            PasswordHasherModel passwordHasher = new PasswordHasherModel();
            //Instansiating the HashPassword method in the PasswordHasher Class to hash the password
            passwordHasher.HashPassword(userAndRoleViewModel.UserDetails.Passwords, out this.hashedPassword, out this.salt);
            var newUser = new UserModel
            {
                Usernames = userAndRoleViewModel.UserDetails.Usernames,
                Passwords = this.hashedPassword,
                Salt = this.salt.ToString(),
                RoleID = 2
            };
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();
            return RedirectToAction("LoginView", "Login");
        }

        //---------------------------------------------------------------//
        /// <summary>
        /// Method that checks if the inputed username already exists in the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool checkIfUsernameIsTaken(string username)
        {
            return _dbContext.User.Any(u => u.Usernames == username);
        }
        //---------------------------------------------------------------//
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//