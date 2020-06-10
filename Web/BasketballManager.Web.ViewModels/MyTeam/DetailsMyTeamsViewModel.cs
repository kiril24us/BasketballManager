namespace BasketballManager.Web.ViewModels.MyTeam
{
    using System.Collections.Generic;

    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class DetailsMyTeamsViewModel
    {
        public IEnumerable<MyTeamViewModel> Teams { get; set; }
    }
}