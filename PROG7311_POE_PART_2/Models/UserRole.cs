using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_POE_PART_2.Models
{
    [Table("UserRole")]
    public class UserRole
    {
        /// <summary>
        /// Variable to store the UserID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Instansiation of the User Model class
        /// </summary>
        public UserModel User { get; set; }

        /// <summary>
        /// Variable to store the RoleID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Instansiation of the role class
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRole() 
        {

        }   
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//