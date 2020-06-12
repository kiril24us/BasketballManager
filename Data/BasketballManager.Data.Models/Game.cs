namespace BasketballManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game()
        {
            this.GameStatistics = new HashSet<GameStatistic>();
        }

        public int Id { get; set; }

        public int MyTeamId { get; set; }

        public Team MyTeam { get; set; }

        public int OpponentTeamId { get; set; }

        public OpponentTeam OpponentTeam { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public ICollection<GameStatistic> GameStatistics { get; set; }
    }
}
