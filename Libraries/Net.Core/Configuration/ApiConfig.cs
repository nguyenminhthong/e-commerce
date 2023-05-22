using Net.Core.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Net.Core.Configuration
{
    public class ApiConfig : IConfig
    {
        public bool EnableGrpcServer { get; set; } = false;

        public bool EnableGrpcClient { get; set; } = false;

        public bool EnableSwagger { get; set; } = true;

        public bool EnableCache { get; set; } = true;

        public bool EnableDapper { get; set; } = true;

        public int CacheTime { get; set; } = 60;

        [JsonConverter(typeof(StringEnumConverter))]
        public DistributedCacheType DistributedCacheType { get; set; } = DistributedCacheType.Redis;
    }
}
