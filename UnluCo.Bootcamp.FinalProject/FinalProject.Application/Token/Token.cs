using System;
using System.Text.Json.Serialization;

namespace FinalProject.Application.Token
{
   public class Token
    {
        [JsonPropertyName("accestoken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("tokenexpiration")]
        public DateTime TokenExpiration { get; set; }
        [JsonPropertyName("refreshtoken")]
        public Guid RefreshToken { get; set; }
        [JsonPropertyName("refreshtokenexpiredate")]
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
