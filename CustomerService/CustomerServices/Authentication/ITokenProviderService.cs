using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.Authentication
{
    public interface ITokenProviderService
    {
        public Task<bool> IsValidTokenAsync(string token);

        public Task<string> GenerateToken();
    }
}
