namespace PROG7311_POE_PART_2.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Variable to store the request ID
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// variable to show the request ID
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//