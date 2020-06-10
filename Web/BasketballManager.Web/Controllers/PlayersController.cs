namespace BasketballManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BasketballManager.Data;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;
    using BasketballManager.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext db;

        public PlayersController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPlayerViewModel input)
        {
            var positionAsEnum = Enum.Parse<PositionType>(input.PositionType);

            var player = new Player
            {
                Name = input.Name,
                Age = input.Age,
                Height = input.Height,
                Kilos = input.Kilos,
                Number = input.Number,
                PositionType = positionAsEnum,
            };

            this.db.Players.Add(player);
            this.db.SaveChanges();
            return this.Redirect("/");
        }

    }
}
