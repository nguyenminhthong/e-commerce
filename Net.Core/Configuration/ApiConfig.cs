using Net.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Configuration
{
    public class ApiConfig : IConfig
    {
        public bool EnableSwagger { get; set; }

        public bool EnableCache { get; set; }

        public bool DapperEnable { get; set; }

        public int CacheTime { get; private set; } = 60;

        public DistributedCacheType DistributedCacheType { get; set; } = DistributedCacheType.Redis;

    }
}
