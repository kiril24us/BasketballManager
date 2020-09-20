namespace BasketballManager.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class DetailsAllGames
    {
        public IEnumerable<DetailsGame> Games { get; set; }
    }
}
