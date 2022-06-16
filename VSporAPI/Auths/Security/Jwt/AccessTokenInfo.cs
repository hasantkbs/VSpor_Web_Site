using System.Collections.Generic;

namespace VSpor.Auths.Security.Jwt
{
    public class AccessTokenInfo 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bolge { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
