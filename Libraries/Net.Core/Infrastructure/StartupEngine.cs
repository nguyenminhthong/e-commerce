using Net.Core.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Infrastructure
{
    public partial class StartupEngine
    {
        public static List<Type> AllNeededStartup { get; set; }

        static StartupEngine()
        {
            AllNeededStartup = new List<Type>()
            {
                typeof(ApiConfig),
                typeof(DatabaseConfig),
                typeof(RedisCacheConfig)
            };

        }

    }
}
