﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Services.Authentication
{
    sealed class AuthenticationDefaults
    {
        /// <summary>
        /// The default value used for authentication scheme
        /// </summary>
        public static string AuthenticationScheme => "Authentication";

        public static string ClaimsIssuer => "Net.Api";

        public static string ClaimUserId => "user_id";

        public static string ClaimUserGuid => "user_guid";
    }
}
