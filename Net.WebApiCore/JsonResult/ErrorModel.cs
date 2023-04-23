namespace Net.WebApiCore.JsonResult
{
    public class ErrorModel
    {
        public string ErrorField { get; set; }

        public string ErrorMessage { get; set; }

        public ErrorModel(string field, string message)
        {
            ErrorField = field;
            ErrorMessage = message;
        }
    }
}
