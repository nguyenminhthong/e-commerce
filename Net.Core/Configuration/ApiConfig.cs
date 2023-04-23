using Net.Core.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Net.Core.Configuration
{
    public class ApiConfig : IConfig
    {
        public bool EnableSwagger { get; set; }

        public bool EnableCache { get; set; }

        public bool EnableDapper { get; set; }

        public int CacheTime { get; set; } = 60;

        [JsonConverter(typeof(StringEnumConverter))]
        public DistributedCacheType DistributedCacheType { get; set; } = DistributedCacheType.Redis;
    }
}
