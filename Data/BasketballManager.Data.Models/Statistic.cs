namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;

    using BasketballManager.Data.Common.Models;

    public class Statistic : BaseDeletableModel<int>
    {
        public double OffensiveRebounds { get; set; }

        public double DefensiveRebounds { get; set; }

        public double Assists { get; set; }

        public double Fouls { get; set; }

        public double PlayedMinutes { get; set; }

        public double ThreePointsAttempt { get; set; }

        public int ThreePointsMade { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
