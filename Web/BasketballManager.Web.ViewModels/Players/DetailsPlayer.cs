namespace BasketballManager.Web.ViewModels.Players
{
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class DetailsPlayer : IMapFrom<Player>
    {
        public string Name { get; set; }
    }
}