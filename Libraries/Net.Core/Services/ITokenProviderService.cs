using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Services
{
    public interface ITokenProviderService
    {
        public Task<bool> IsValidTokenAsync(string token);

        public Task<string> GenerateToken();
    }
}
