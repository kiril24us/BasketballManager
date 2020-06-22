namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;

    using BasketballManager.Data.Common.Models;

    public class Statistic : BaseDeletableModel<int>
    {
        public int OffensiveRebounds { get; set; }

        public int DefensiveRebounds { get; set; }

        public int Assists { get; set; }

        public int Fouls { get; set; }

        public int PlayedMinutes { get; set; }

        public int ThreePointsAttempt { get; set; }

        public int ThreePointsMade { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
