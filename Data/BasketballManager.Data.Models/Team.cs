﻿namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using BasketballManager.Data.Common.Models;

    public class Team : BaseDeletableModel<int>
    {
        public Team()
        {
            this.Games = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string Coach { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
