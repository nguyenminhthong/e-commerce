using Newtonsoft.Json;

namespace Net.API.JsonResult
{
    public class ErrorRootObject
    {
        [JsonProperty("errors")]
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
