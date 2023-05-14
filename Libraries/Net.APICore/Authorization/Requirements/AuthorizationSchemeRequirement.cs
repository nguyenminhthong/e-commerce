using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Authorization.Requirements
{
    public class AuthorizationSchemeRequirement : IAuthorizationRequirement
    {
        public bool IsValid(IHeaderDictionary requestHeaders)
        {
            if (requestHeaders != null
                && requestHeaders.ContainsKey("Authorization")
                && requestHeaders["Authorization"].ToString().Contains(JwtBearerDefaults.AuthenticationScheme))
            {
                return true;
            }
            return false;
        }
    }
}
