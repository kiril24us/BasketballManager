namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;

    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<GameStatistic>();
        }

        public int Id { get; set; }

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
