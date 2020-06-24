namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BasketballManager.Data.Common.Models;

    public class Statistic : BaseModel<int>
    {
        [Required]
        public int OffensiveRebounds { get; set; }

        [Required]
        public int DefensiveRebounds { get; set; }

        [Required]
        public int Assists { get; set; }

        [Required]
        public int Fouls { get; set; }

        [Required]
        public int PlayedMinutes { get; set; }

        [Required]
        public int ThreePointsAttempt { get; set; }

        [Required]
        public int ThreePointsMade { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
