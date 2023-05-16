using Net.APICore.Model;

namespace Net.API.ViewModel.Authentication
{
    public record LoginModel : BaseModel
    {
        public string UserName { get; set; } = "";

        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }
    }
}
