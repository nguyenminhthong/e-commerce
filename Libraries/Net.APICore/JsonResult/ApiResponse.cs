namespace Net.APICore.JsonResult
{
    public record ApiResponse
    {
        public string? Message { get; set; }

        public dynamic? Data { get; set; }

        public dynamic? Error { get; set; }
    }
}
