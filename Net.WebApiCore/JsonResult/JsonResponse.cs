namespace Net.WebApiCore.JsonResult
{
    public record JsonDataResponse
    {
        public string Message { get; set; } = "";

        public dynamic? Data { get; set; }

        public dynamic? Error { get; set; }
    }
}
