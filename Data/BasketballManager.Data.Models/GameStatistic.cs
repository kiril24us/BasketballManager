namespace BasketballManager.Data.Models
{
    public class GameStatistic
    {
        public int StatisticId { get; set; }

        public Statistic Statistic { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
