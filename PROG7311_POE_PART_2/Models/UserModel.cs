using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_POE_PART_2.Models
{

    [Table("Users")]
    public class UserModel
    {

        /// <summary>
        /// Variable to store the userID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        ///variable to store the Users ID
        public int UserID { get; set; }

        /// <summary>
        /// Variable to store the username
        /// </summary>
        private string usernames = string.Empty;

        /// <summary>
        /// variable to store the Role ID
        /// </summary>
        private int roleID;
        /// <summary>
        /// variable to store the password
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        private string passwords = string.Empty;

        /// <summary>
        /// variable to store the salt that was used to hash the users password
        /// </summary>
        private string salt = string.Empty;

        /// <summary>
        /// List that stores the UserRoles
        /// </summary>
        public List<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Creation of getter and setter
        /// </summary>
        public string Usernames { get => usernames; set => usernames = value; }

        /// <summary>
        /// Creation of getter and setter
        /// </summary>
        public string Passwords { get => passwords; set => passwords = value; }

        /// <summary>
        /// Creation of getter and setter
        /// </summary>
        public string Salt { get => salt; set => salt = value; }

        /// <summary>
        /// Variable to store the RoleID
        /// </summary>
        public int RoleID { get => roleID; set => roleID = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserModel() 
        {

        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//