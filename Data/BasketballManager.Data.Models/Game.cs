namespace BasketballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BasketballManager.Data.Common.Models;

    public class Game : BaseDeletableModel<int>
    {
        public int MyPoints { get; set; }

        public int OpponentPoints { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public int OpponentId { get; set; }

        public virtual Team Team { get; set; }
    }
}
