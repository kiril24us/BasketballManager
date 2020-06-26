namespace BasketballManager.Web.ViewModels.MyTeam
{
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class MyTeamViewModel : IMapFrom<Team>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
