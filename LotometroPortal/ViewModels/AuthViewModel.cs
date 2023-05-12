using Newtonsoft.Json;

namespace LotometroPortal.ViewModels
{
    public class AuthViewModel
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
