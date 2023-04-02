using Microsoft.AspNetCore.Mvc;

namespace NetCore.JsonResult
{
    class RawJsonResult<T>: ActionResult
    {
        public static RawJsonResult<T> Send(T pResponse, String pMessage = "success", int pStatusCode = 200)
        {
            return new RawJsonResult<T>(pResponse, pMessage, pStatusCode);
        }

        private readonly JsonDataResponse _jsonData;
        private readonly int _statusCode;

        public RawJsonResult(T pResult, String pMessage = "success", int pStatusCode = 200)
        {
            _jsonData = new JsonDataResponse()
            {
                Data = pResult,
                message = pMessage
            };

            _statusCode = pStatusCode;
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = _statusCode;

            return response.WriteAsJsonAsync(_jsonData);
        }
    }
}
