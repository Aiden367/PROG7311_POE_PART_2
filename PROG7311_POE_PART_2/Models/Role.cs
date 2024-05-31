using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_POE_PART_2.Models
{
    [Table("RoleTable")]
    public class Role
    {
        /// <summary>
        /// Variable to store the userID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        ///Variable to store the roles ID
        public int ID { get; set; }

        /// <summary>
        /// variable to store the roles name
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// variable to store the Users Roles
        /// </summary>
        public List<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Role()
        {

        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//