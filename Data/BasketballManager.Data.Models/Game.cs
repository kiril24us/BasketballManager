namespace BasketballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BasketballManager.Data.Common.Models;

    public class Game : BaseDeletableModel<int>
    {
        [Required]
        public int MyPoints { get; set; }

        [Required]
        public int OpponentPoints { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public int OpponentId { get; set; }

        public virtual Team Team { get; set; }
    }
}
