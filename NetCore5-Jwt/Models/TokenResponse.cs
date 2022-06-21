using System;

namespace NetCore5_Jwt.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
