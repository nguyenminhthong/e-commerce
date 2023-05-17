using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.Core.Extensions;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Net.APICore.JsonResult
{
    internal class RawJsonResult : ActionResult
    {
        #region Field
        public ApiResponse DataResponse { get; private set; } = new ApiResponse();

        public int StatusCode { get; private set; } = 200;
        #endregion

        #region Constructor

        public RawJsonResult()
        {

        }

        public RawJsonResult(dynamic iData)
        {
            DataResponse = new ApiResponse
            {
                Data = iData,
                Message = ApiStatus.SUCCESS.GetValueString()
            };
        }
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
            var res = new RawJsonResult()
            {
                DataResponse = new ApiResponse()
                {
                    Message = ApiStatus.SUCCESS.GetValueString(),
                },
                StatusCode = 200
            };

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> Send<T>(T iData) where T : class
        {
            var res = new RawJsonResult()
            {
                DataResponse = new ApiResponse()
                {
                    Data = iData,
                    Message = ApiStatus.SUCCESS.GetValueString()
                },
                StatusCode = 200
            };

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> BabRequest<T>(T errors)
        {
            var res = new RawJsonResult()
            {
                DataResponse = new ApiResponse()
                {
                    Error = errors,
                    Message = ApiStatus.ERROR.GetValueString()
                },
                StatusCode = 400
            };

            return await Task.FromResult(res);
        }

        public static async Task<IActionResult> Error(string message)
        {
            var res = new RawJsonResult()
            {
                DataResponse = new ApiResponse()
                {
                    Message = message
                },
                StatusCode = 500
            };

            return await Task.FromResult(res);
        }

        #endregion

    }
}
