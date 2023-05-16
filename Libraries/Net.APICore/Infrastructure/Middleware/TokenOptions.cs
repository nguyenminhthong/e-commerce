using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Infrastructure.Middleware
{
    public class TokenOptions
    {
        public string Path { get; set; }

        public TimeSpan Expiration { get; set; }

    }
}
