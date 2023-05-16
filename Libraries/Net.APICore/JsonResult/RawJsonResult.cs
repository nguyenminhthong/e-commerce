using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.Core.Extensions;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.Serialization;

namespace Net.APICore.JsonResult
{
    internal class RawJsonResult: ActionResult
    {
        #region Field
        public ApiResponse DataResponse { get; private set; } = new ApiResponse();
        
        public int StatusCode { get; private set; } = 200;
        #endregion
        
        #region Utils
        public override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = StatusCode;

            return response.WriteAsync(JsonConvert.SerializeObject(DataResponse));
        }
        #endregion

        #region Method

        public static async Task<IActionResult> Send()
        {
            var res = new RawJsonResult();
            var _success = ApiStatus.SUCCESS;
            res.DataResponse = new ApiResponse()
            {
                Message = _success.GetValueString(),
            };

            res.StatusCode = 200;

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> Send<T>(T pResponse, ApiStatus pMessage = ApiStatus.SUCCESS, int pStatusCode = 200) where T : class
        {
            var res = new RawJsonResult();
            res.DataResponse = new ApiResponse()
            {
                Data = pResponse,
                Message = pMessage.GetValueString()
            };

            res.StatusCode = pStatusCode;

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> BabRequest<T>(T errors)
        {
            var res = new RawJsonResult();

            res.DataResponse = new ApiResponse()
            {
                Message = ApiStatus.ERROR.GetValueString(),
                Error = errors
            };

            res.StatusCode = 400;

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> Error(string message)
        {
            var res = new RawJsonResult();

            res.DataResponse = new ApiResponse()
            {
                Message = message
            };

            res.StatusCode = 500;

            return await Task.FromResult(res);
        }
        #endregion

    }
}
