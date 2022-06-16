using VSpor.Auths.Extensions;
using VSpor.Auths.User;
using VSpor.IoC;
using System.Security;


namespace VSpor.Auths.Security.SecuredOperation
{
    public class SecuredOperation
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public List<string> RoleControl()
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return roleClaims;
                }
            }
            throw new SecurityException(UserMessages.AuthorizationDenied);
        }
    }
}
