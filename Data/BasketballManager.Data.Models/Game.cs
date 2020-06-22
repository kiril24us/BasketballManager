namespace BasketballManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using BasketballManager.Data.Common.Models;

    public class Game : BaseDeletableModel<int>
    {
        public int MyPoints { get; set; }

        public int OpponentPoints { get; set; }

        public DateTime Date { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
