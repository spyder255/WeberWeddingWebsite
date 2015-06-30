using Newtonsoft.Json;

namespace SamMorganWeddingPortal
{
    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public object[] ErrorCodes { get; set; }
    }
}