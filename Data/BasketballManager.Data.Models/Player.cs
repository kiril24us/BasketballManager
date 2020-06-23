namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BasketballManager.Data.Common.Models;

    public class Player : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 80)]
        public int Age { get; set; }

        [Required]
        [Range(1, 300)]
        public double Height { get; set; }

        [Required]
        [Range(1, 200)]
        public double Kilos { get; set; }

        [Required]
        [Range(0, 99)]
        public int Number { get; set; }

        public PositionType PositionType { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
