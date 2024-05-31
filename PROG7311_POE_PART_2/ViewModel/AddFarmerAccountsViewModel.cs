using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.ViewModel
{
    public class AddFarmerAccountsViewModel
    {
        /// <summary>
        /// List to store the names of all of the roles
        /// </summary>
        public List<string> userRoleList { get; set; }

        /// <summary>
        /// List to store all of the usernames
        /// </summary>
        public List<string> usernameList { get; set; }

        /// <summary>
        /// variable to store the selected user role
        /// </summary>
        public string selectedUserRole { get; set; }

        /// <summary>
        /// variable to store the selected username
        /// </summary>
        public string selectedUsername { get; set; }

        /// <summary>
        /// instansiation of the Usermodel class
        /// </summary>
        public UserModel Users { get; set; }

        /// <summary>
        /// Instansiation of the UserRole class
        /// </summary>
        public UserRole UserRoles { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AddFarmerAccountsViewModel()
        {

        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//