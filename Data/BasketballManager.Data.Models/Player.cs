namespace BasketballManager.Data.Models
{
    using System.Collections.Generic;

    using BasketballManager.Data.Common.Models;

    public class Player : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public double Kilos { get; set; }

        public int Number { get; set; }

        public PositionType PositionType { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
