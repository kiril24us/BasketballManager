namespace BasketballManager.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class DetailsGame : IMapFrom<Game>
    {
        public int MyPoints { get; set; }

        public int OpponentPoints { get; set; }

        public int OpponentId { get; set; }

        public string TeamName { get; set; }

        public string OpponentName { get; set; }

        public DateTime Date { get; set; }
    }
}
