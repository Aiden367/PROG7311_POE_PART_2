using System.Diagnostics;
using System.Security.Cryptography;

namespace PROG7311_POE_PART_2.Models
{
    public class PasswordHasherModel
    {
       /// <summary>
       /// Constructor
       /// </summary>
       public PasswordHasherModel() 
        {

        }

        //---------------------------------------------------------------//
        /// <summary>
        /// Method to hash the users entered password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string HashPassword(string password, out string hashedPassword, out string salt)
        {
            byte[] saltBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            // Convert the salt to a base64 string for storage
            salt = Convert.ToBase64String(saltBytes);
            // Combine the salt and password, then hash them
            string combined = string.Concat(password, salt);
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(combined));
                hashedPassword = Convert.ToBase64String(hashedBytes);
            }
            return hashedPassword;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Module That hashes the entered password and checks if the hashed entered password matches the stored hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHashedPassword"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string storedHashedPassword, string storedSalt)
        {
            // Convert the stored salt back to bytes
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            // Combine the user-entered password with the stored salt
            string combined = string.Concat(password, storedSalt);
            // Hash the combined value
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(combined));
                string inputHashedPassword = Convert.ToBase64String(hashedBytes);
                Debug.WriteLine("input hashed password:" + inputHashedPassword);
                // Compare the input hashed password with the stored hashed password
                return string.Equals(inputHashedPassword, storedHashedPassword);
            }
        }
        //---------------------------------------------------------------//
    }
}
//-------------------------------------------END OF FILE----------------------------------------//