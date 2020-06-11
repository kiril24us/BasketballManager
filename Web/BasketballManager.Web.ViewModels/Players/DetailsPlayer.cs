namespace BasketballManager.Web.ViewModels.Players
{
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class DetailsPlayer : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public double Kilos { get; set; }

        public int Number { get; set; }

        public string PositionType { get; set; }
    }
}
