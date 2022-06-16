using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VSpor.Auths.Extensions;
using VSpor.Auths.Security.Encyption;
using VSpor.Auths.User;
using VSpor.IoC;
using VSporCore.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;


namespace VSpor.Auths.Security.Jwt
{
    public class JwtHelper 
    {
        private IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(Account user)
        {
            _accessTokenExpiration = DateTime.Now.AddSeconds(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _tokenOptions.AccessTokenExpiration,
                TokenType = "Bearer",
                RefreshToken = ""
            };

        }

        public AccessTokenInfo GetTokenInfo()
        {
            var httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            var claimpPrincipal = httpContextAccessor.HttpContext.User;
            int.TryParse(claimpPrincipal.ClaimValue(ClaimTypes.NameIdentifier), out var id);

            return new AccessTokenInfo
            {
                Id = id,
                Bolge = claimpPrincipal.ClaimValue(ClaimTypes.Email), //Bolge kayıtlı
                FullName = claimpPrincipal.ClaimValue(ClaimTypes.Name),
                Roles = claimpPrincipal.ClaimRoles()
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Account user,
       SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserDto user,
        //    SigningCredentials signingCredentials, List<UserPrivilegeDto> operationClaims)
        //{
        //    var jwt = new JwtSecurityToken(
        //        issuer: tokenOptions.Issuer,
        //        audience: tokenOptions.Audience,
        //        expires: _accessTokenExpiration,
        //        notBefore: DateTime.Now,
        //        claims: SetClaims(user, operationClaims),
        //        signingCredentials: signingCredentials
        //    );
        //    return jwt;
        //}


        private IEnumerable<Claim> SetClaims(Account user)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName(user.UserName);
            claims.AddEmail(user.Bolge); //Bolge kayıtlı
            if (user.Roles.IsNotNull())
            {
                claims.AddRoles(user.Roles.Select(c => c.Name).ToArray());
            }
            return claims;
        }
        //private IEnumerable<Claim> SetClaims(UserDto user, IReadOnlyCollection<UserPrivilegeDto> operationClaims)
        //{
        //    var claims = new List<Claim>();
        //    claims.AddNameIdentifier(user.Id.ToString());
        //    claims.AddEmail(user.Email);
        //    claims.AddName($"{user.Name} {user.Surname}");
        //    if (operationClaims.IsNotNull())
        //        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

        //    return claims;
        //}
    }
}
