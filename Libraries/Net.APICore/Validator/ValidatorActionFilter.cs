using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Net.APICore.JsonResult;
using Net.Core.Extensions;
using Newtonsoft.Json;
using System.Net;

namespace Net.APICore.Validator
{
    public class ValidatorActionFilter : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
            }
            else
            {
                var errors = context.ModelState.Where(x => x.Value != null && x.Value.Errors.Any())
                                    .Select(x => ErrorMapping(x))
                                    .ToList();
                var res = new RawJsonResult()
                {
                    DataResponse = new ApiResponse()
                    {
                        Error = errors,
                        Message = ApiStatus.ERROR.GetValueString()
                    },
                    StatusCode = 400
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(res));
            }
        }

        private ErrorModel ErrorMapping(KeyValuePair<String, ModelStateEntry> error)
        {
            return new ErrorModel(error.Key, error.Value.Errors.Select(x => x.ErrorMessage).FirstOrDefault() ?? "");
        }
    }
}
