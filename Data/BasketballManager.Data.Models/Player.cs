namespace BasketballManager.Data.Models
{
    using BasketballManager.Data.Common.Models;
    using System.Collections.Generic;

    public class Player : BaseDeletableModel<int>
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<GameStatistic>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public double Kilos { get; set; }

        public int Number { get; set; }

        public int MyTeamId { get; set; }

        public virtual MyTeam MyTeam { get; set; }

        public PositionType PositionType { get; set; }

        public ICollection<GameStatistic> PlayerStatistics { get; set; }
    }
}
