using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Configuration
{
    public class GrpcMiddlewareAuthen : IConfig
    {
        public bool EnableGrpc { get; set; } = true;

        public string ApiPermissionCheck { get; set; }

        public string ApiTokenRefresh { get; set; }

        public string ApiTokenCheck { get; set; }
    }
}
