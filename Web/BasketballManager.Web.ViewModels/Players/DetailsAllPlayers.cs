namespace BasketballManager.Web.ViewModels.Players
{
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;
    using System.Collections;
    using System.Collections.Generic;

    public class DetailsAllPlayers
    {
        IEnumerable<DetailsPlayer> Players { get; set; }
    }
}
