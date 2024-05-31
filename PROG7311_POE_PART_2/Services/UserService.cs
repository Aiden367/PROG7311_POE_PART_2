using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.DbContexts;
using PROG7311_POE_PART_2.Models;
using System.Diagnostics;

namespace PROG7311_POE_PART_2.Services
{
    public class UserService
    {
        /// <summary>
        /// instansiation of the PROGPOE dbcontext 
        /// </summary>
        private readonly PROGPOEContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserService(PROGPOEContext context)
        {
            _context = context;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Async method that finds the user and the role details and then updates that users role with the new role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<bool> AddRoleToUserAsync(string userName, string roleName)
        {
            // Find the user by their username
            var user = await _context.User
                                     .FirstOrDefaultAsync(u => u.Usernames == userName);
            // Find the role by its name
            var role = await _context.Roles
                                     .FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (user == null || role == null)
            {
                Debug.Write("User or Role not found");
                return false;
            }
            user.RoleID = role.ID;
            // Update the user entity with the new role
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Method that removes the role from the selected user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveRoleFromUserAsync(int userId, int roleId)
        {
            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRole == null)
            {
                return false;
            }
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
            return true;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// MEthod that recieves all of the users roles
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Role>> GetUserRolesAsync(int userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role)
                .ToListAsync();
        }
        //---------------------------------------------------------------//
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//