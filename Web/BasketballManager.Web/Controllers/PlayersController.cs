namespace BasketballManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BasketballManager.Data;
    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Data;
    using BasketballManager.Services.Mapping;
    using BasketballManager.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : Controller
    {
        private readonly IPlayersService playersService;

        public PlayersController(IPlayersService playersService)
        {
            this.playersService = playersService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddPlayerViewModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.playersService.Register(input.Name, input.Age, input.Height, input.Kilos, input.Number, input.PositionType, id);
            return this.Redirect("/MyTeam/Details");
        }

        public IActionResult All()
        {

        }
    }
}
