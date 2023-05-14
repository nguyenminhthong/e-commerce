using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Configuration
{
    public class SecurityConfig : IConfig
    {
        public string CorsPolicyKey { get; set; } = "NET.API";

        public string SecurityKey { get; set; } = "Token@Security@1029384756!@#";

        public int ExpireDate { get; set; } = 1;

        public string PathLogin { get; set; } = "/auth/signin";
    }
}
