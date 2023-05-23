using Newtonsoft.Json;

namespace Customer.Api.Models.Payload
{
    public class TokenResponse
    {
        [JsonProperty("access_token", Required = Required.Always)]
        public string AccessToken { get; init; } = "";

        [JsonProperty("token_type", Required = Required.Always)]
        public string TokenType { get; init; } = "Bearer";

        [JsonProperty("created_at_utc")]
        public DateTime CreatedAtUtc { get; init; }

        [JsonProperty("expires_at_utc")]
        public DateTime ExpiresAtUtc { get; init; }

        [JsonProperty("username")]
        public string Username { get; init; } = "";

        [JsonProperty("customer_id")]
        public int CustomerId { get; init; }

        [JsonProperty("customer_guid")]
        public Guid CustomerGuid { get; init; }
    }
}
