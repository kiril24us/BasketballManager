namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using BasketballManager.Data.Common.Models;

    public class Team : BaseDeletableModel<int>
    {
        public Team()
        {
            this.Games = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public string Coach { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Choose what type of Team is this!")]
        public bool IsManaged { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
