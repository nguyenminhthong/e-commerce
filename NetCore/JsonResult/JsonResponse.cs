namespace NetCore.JsonResult
{
    public record JsonDataResponse
    {
        public String message { get; set; } = "";

        public dynamic? Data { get; set; }
    }
}
