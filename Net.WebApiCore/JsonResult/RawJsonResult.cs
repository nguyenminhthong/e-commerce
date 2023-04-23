using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.Core.Extensions;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.Serialization;

namespace Net.WebApiCore.JsonResult
{
    internal class RawJsonResult: ActionResult
    {
        #region Field
        public JsonDataResponse DataResponse { get; private set; } = new JsonDataResponse();
        
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

        public static async Task<IActionResult> BabRequest<T>(T errors)
        {
            var res = new RawJsonResult();

            res.DataResponse = new JsonDataResponse()
            {
                Message = StatusResponse.ERROR.ToString(),
                Error = errors
            };

            res.StatusCode = 400;

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> Send()
        {
            var res = new RawJsonResult();
            var _success = StatusResponse.SUCCESS;
            res.DataResponse = new JsonDataResponse()
            {
                Message = _success.GetValueString(),
            };

            res.StatusCode = 200;

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> Send<T>(T pResponse, StatusResponse pMessage = StatusResponse.SUCCESS, int pStatusCode = 200) where T : class
        {
            var res = new RawJsonResult();
            res.DataResponse = new JsonDataResponse()
            {
                Data = pResponse,
                Message = pMessage.GetValueString()
            };

            res.StatusCode = pStatusCode;

            return await Task.FromResult(res);
        } 
        #endregion

    }
}
