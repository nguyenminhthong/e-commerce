using Net.APICore.Model;

namespace Customer.Api.Models.Request
{
    public record LoginModel : BaseModel
    {
        public string UserName { get; set; } = "";

        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }
    }
}
