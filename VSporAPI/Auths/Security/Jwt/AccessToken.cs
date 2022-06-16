using System.Text.Json.Serialization;


namespace VSpor.Auths.Security.Jwt
{
    public class AccessToken 
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int Expiration { get; set; }

        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
