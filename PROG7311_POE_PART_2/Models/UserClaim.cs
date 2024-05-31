namespace PROG7311_POE_PART_2.Models
{
    public class UserClaim
    {
        /// <summary>
        /// Variable to store the User Claim ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// variable to store the UserID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// variable to store the claim type
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// variable to store the claim value
        /// </summary>
        public string ClaimValue { get; set; }

        /// <summary>
        /// instansiating the UserModel
        /// </summary>
        public UserModel User { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserClaim() 
        {

        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//