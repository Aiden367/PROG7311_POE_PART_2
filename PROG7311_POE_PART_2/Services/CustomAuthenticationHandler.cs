using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PROG7311_POE_PART_2.DbContexts;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace PROG7311_POE_PART_2.Services
{
    public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        /// <summary>
        /// instansiation of the PROGPOE DB context
        /// </summary>
        private readonly PROGPOEContext _context;

        //---------------------------------------------------------------//
        /// <summary>
        /// Authentication method that handles the authentication of users
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <param name="encoder"></param>
        /// <param name="clock"></param>
        /// <param name="context"></param>
        public CustomAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            PROGPOEContext context)
            : base(options, logger, encoder, clock)
        {
            _context = context;
        }
        //---------------------------------------------------------------//
        /// <summary>
        /// Async method that handles the Authentication and assigning of roles to the users 
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, "username"),
            };
            var user = await _context.User
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Usernames == "username"); // Replace with actual username lookup
            if (user != null)
            {
                foreach (var userRole in user.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole.Role.RoleName));
                }
            }
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
        //---------------------------------------------------------------//
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//