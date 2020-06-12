namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;

    public class Statistic
    {
        public Statistic()
        {
            this.Games = new HashSet<GameStatistic>();
        }

        public int Id { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public int OffensiveRebounds { get; set; }

        public int DefensiveRebounds { get; set; }

        public int Assists { get; set; }

        public int Fouls { get; set; }

        public int PlayedMinutes { get; set; }

        public int ThreePointsAttempt { get; set; }

        public int ThreePointsMade { get; set; }

        public ICollection<GameStatistic> Games { get; set; }
    }
}
