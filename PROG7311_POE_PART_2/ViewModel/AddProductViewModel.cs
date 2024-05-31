using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.ViewModel
{
    public class AddProductViewModel
    {
        /// <summary>
        /// Instansiation of the AddProductModel
        /// </summary>
        public AddProductModel AddProductModel { get; set; }

        /// <summary>
        /// AddProductModel Object list to store all of the products
        /// </summary>
        public List<AddProductModel> ProductsListProductModel { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public AddProductViewModel() 
        {

        }
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//