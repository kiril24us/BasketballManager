namespace BasketballManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading.Tasks;

    using BasketballManager.Data;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Data;
    using BasketballManager.Web.ViewModels.Games;
    using BasketballManager.Web.ViewModels.MyTeam;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class GamesController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IGamesService gamesService;
        private readonly UserManager<ApplicationUser> userManager;

        public GamesController(
                                ITeamService teamService,
                                IGamesService gamesService,
                                UserManager<ApplicationUser> userManager)
        {
            this.teamService = teamService;
            this.gamesService = gamesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult RegisterGame()
        {
            var userId = this.userManager.GetUserId(this.User);
            DateTime now = DateTime.UtcNow;
            var viewModel = new RegisterGameViewModel();
            var teams = this.teamService.GetMyTeamsById<MyTeamViewModel>(userId);
            var opponents = this.teamService.GetOpponentsById<MyTeamViewModel>(userId);
            viewModel.Teams = teams;
            viewModel.Opponents = opponents;
            viewModel.DateNow = now;
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RegisterGame(RegisterGameViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.gamesService.RegisterGame(input.MyTeamId, input.OpponentId, input.MyPoints, input.OpponentPoints, input.Date);
            this.TempData["InfoMessage"] = "Game was created!";
            return this.Redirect("/");
        }

        public IActionResult GamesDetailsByTeamId(int id)
        {
                var viewModel = new DetailsAllGames();
                var games = this.gamesService.DetailsGames<DetailsGame>(id);
                viewModel.Games = games;
                return this.View(viewModel);
        }

        [Authorize]
        public IActionResult GamesDetailsForAllTeams()
        {
            var viewModel = new DetailsAllGames();
            var userId = this.userManager.GetUserId(this.User);
            var games = this.gamesService.DetailsAllGames<DetailsGame>(userId);
            viewModel.Games = games;
            return this.View(viewModel);
        }

        public IActionResult Proba()
        {
            var viewModel = new Proba();
            var userId = this.userManager.GetUserId(this.User);
            var games = this.gamesService.Proba<Probi>(userId);
            viewModel.Probis = games;
            return this.View(viewModel);
        }
    }
}
