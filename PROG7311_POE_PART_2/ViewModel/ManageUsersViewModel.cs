using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.ViewModel
{
    public class ManageUsersViewModel
    {
        /// <summary>
        /// List to store the names of all the farmers
        /// </summary>
        public List<string> farmerNamesList { get; set; }

        /// <summary>
        /// List to store all of the categories
        /// </summary>
        public List<string> productCategoryList { get; set; }

        /// <summary>
        /// List to store all of the products
        /// </summary>
        public List<AddProductModel> ProductsList { get; set; }

        /// <summary>
        /// List to store all of the user roles
        /// </summary>
        public List<string> userRoleList { get; set; }

        /// <summary>
        /// List to store all of the usernames
        /// </summary>
        public List<string> usernameList { get; set; }

        /// <summary>
        /// Instansiation of the AddProductModel
        /// </summary>
        public AddProductModel Product { get; set; }

        /// <summary>
        /// Variable to store the selected user role
        /// </summary>
        public string selectedUserRole { get; set; }

        /// <summary>
        /// variable to store the selected username
        /// </summary>
        public string selectedUsername { get; set; }

        /// <summary>
        /// variable to store the selected farmer name
        /// </summary>
        public string selectedFarmerName { get; set; }

        /// <summary>
        /// variable to store the selected product category
        /// </summary>
        public string selectedProductCategory { get; set; }

        /// <summary>
        /// variable to store the selected date
        /// </summary>
        public DateTime selectedDate { get; set; } 

        //variablr to store the searched product name
        public string searchedProductName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ManageUsersViewModel() 
        {
            ProductsList = new List<AddProductModel>(); 
            farmerNamesList = new List<string>();
            productCategoryList = new List<string>();
            selectedDate = DateTime.Now;
        } 
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//