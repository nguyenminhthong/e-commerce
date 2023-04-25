using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Net.Core.Configuration
{
    public class DatabaseConfig : IConfig
    {
        public string ConnectionString { get; set; } = string.Empty;

        [JsonConverter(typeof(StringEnumConverter))]
        public string DataProvider { get; set; } = string.Empty;
    }
}