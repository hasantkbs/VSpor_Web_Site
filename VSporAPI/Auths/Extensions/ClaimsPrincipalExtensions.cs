using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace VSpor.Auths.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string ClaimValue(this ClaimsPrincipal claims, string claimTypes)
        {
            return claims.Claims.FirstOrDefault(x => x.Type == claimTypes)?.Value;
        }

        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
