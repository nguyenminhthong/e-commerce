using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Configuration
{
    public class GrpcSettings : IConfig
    {
        public string NetAuthService { get; set; }
    }
}
