using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Authorization.Attributes
{
    class AuthorizePermissionFilter : IAsyncAuthorizationFilter
    {
        #region Variable
        private readonly string permission = "";
        private readonly bool ignoreFilter = false;

        #endregion

        #region Constructor

        public AuthorizePermissionFilter(string permissionSystemName, bool ignore = false)
        {
            permission = permissionSystemName;
            ignoreFilter = ignore;
        }

        #endregion

        #region Functionality

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await AuthorizePermissionAsync(context);
        }

        #endregion

        #region Self Func

        private async Task AuthorizePermissionAsync(AuthorizationFilterContext context)
        {
            var actionFilter = context.ActionDescriptor.FilterDescriptors
                            .Where(filter => FilterScope.Action.Equals(filter.Scope))
                            .Select(filter => filter.Filter)
                            .OfType<AuthorizePermissionAttribute>()
                            .Where(auth => auth.PermissionName.Equals(permission))
                            .FirstOrDefault();

            if (actionFilter is not null && actionFilter.IgnoreFilter)
                return;
            await Task.CompletedTask;
        }
        #endregion
    }
}
