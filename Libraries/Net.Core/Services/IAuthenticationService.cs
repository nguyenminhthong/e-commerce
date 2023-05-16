using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Services
{
    public interface IAuthenticationService
    {
        public Task SignInAsync(string username, string password);

        public Task SignOutAsync();
    }
}
