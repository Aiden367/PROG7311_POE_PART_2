using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.ViewModel
{
    public class AssignRoleViewModel
    {
        /// <summary>
        /// Insasiation of the UserModel class
        /// </summary>
        public UserModel Users { get; set; }

        /// <summary>
        /// Instansiation of the User Role class
        /// </summary>
        public UserRole UserRoles { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AssignRoleViewModel() 
        {
            Users = new UserModel();
            UserRoles = new UserRole();
        }    
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//