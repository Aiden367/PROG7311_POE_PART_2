namespace PROG7311_POE_PART_2.Services
{
    public class UserProfileService
    {
        /// <summary>
        /// Variable to store the UserID of the user that logged in so that it can be used  across View Models
        /// </summary>
        private static int sharedUserID;

        private static string username;
        /// <summary>
        /// Variable to store the UserID of the user that logged in so that it can be used  across View Models
        /// </summary>
        public static int SharedUserID { get => sharedUserID; set => sharedUserID = value; }

        /// <summary>
        /// variable to store the username
        /// </summary>
        public static string Username { get => username; set => username = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserProfileService() 
        {

        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//