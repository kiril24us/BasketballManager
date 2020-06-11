namespace BasketballManager.Web.ViewModels.MyTeam
{
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class MyTeamViewModel : IMapFrom<MyTeam>
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string Url => $"/Players/Add/{this.Id}";
    }
}
