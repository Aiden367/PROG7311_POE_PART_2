using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.ViewModel
{
    public class UserDetailsAndRoleViewModel
    {
        /// <summary>
        /// Instansiation of the UserModel class
        /// </summary>
        public UserModel UserDetails { get; set; }

        /// <summary>
        /// Instansiation of the Role Details class
        /// </summary>
        public UserRole RoleDetails { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserDetailsAndRoleViewModel() 
        {
            UserDetails = new UserModel();
            RoleDetails = new UserRole();
        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//