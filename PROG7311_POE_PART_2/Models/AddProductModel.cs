using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_POE_PART_2.Models
{
    [Table("ProductDetailsTable")]
    public class AddProductModel
    {
        /// <summary>
        /// Variable to store the ProductsID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        /// <summary>
        /// Variable to store the users ID
        /// </summary>
        private int userID;

        /// <summary>
        /// Variable to store the products name
        /// </summary>
        private string productName = string.Empty;

        /// <summary>
        /// variable to store the products description
        /// </summary>
        private string productDescription = string.Empty;

        /// <summary>
        /// variable to store the date the product was listed
        /// </summary>
        private DateTime dateProductListed = DateTime.Now;

        /// <summary>
        /// variable to store the products category
        /// </summary>
        private string productCategory = string.Empty;

        /// <summary>
        /// variable to store the farmers name
        /// </summary>
        private string farmerName = string.Empty;

        /// <summary>
        /// Getter and setter for the product name
        /// </summary>
        public string ProductName { get => productName; set => productName = value; }

        /// <summary>
        /// Getter and setter for the products description
        /// </summary>
        public string ProductDescription { get => productDescription; set => productDescription = value; }

        /// <summary>
        /// Getter and setter for the date the product was listed
        /// </summary>
        public DateTime DateProductListed { get => dateProductListed; set => dateProductListed = value; }

        /// <summary>
        /// Getter and setter for the product category
        /// </summary>
        public string ProductCategory { get => productCategory; set => productCategory = value; }

        /// <summary>
        /// Getter and setter for the farmers name
        /// </summary>
        public string FarmerName { get => farmerName; set => farmerName = value; }

        /// <summary>
        /// Getter and setter for the users ID
        /// </summary>
        public int UserID { get => userID; set => userID = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AddProductModel()
        {
        // ProductsListProductModel = new List<AddProductModel>();
        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//