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
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await AuthorizePermissionAsync(context);
        }

        #region Self Func

        private async Task AuthorizePermissionAsync(AuthorizationFilterContext context)
        {
            context.Result = new StatusCodeResult((int) HttpStatusCode.OK);

            await Task.CompletedTask;
        }
        #endregion
    }
}
