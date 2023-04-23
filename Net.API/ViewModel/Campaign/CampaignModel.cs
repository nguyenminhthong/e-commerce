using Net.WebApiCore.Model;

namespace NetCore.ViewModel.Campaign
{
    public record CampaignModel : BaseModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Url { get; set; } = "";

        public string Description { get; set; } = "";
        
        public string ImageCapture { get; set; } = "";
    }
}
