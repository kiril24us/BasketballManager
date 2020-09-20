namespace BasketballManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using BasketballManager.Data;
    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Data;
    using BasketballManager.Services.Mapping;
    using BasketballManager.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : Controller
    {
        private readonly IPlayersService playersService;
        private readonly IWebHostEnvironment hostEnvironment;

        public PlayersController(IPlayersService playersService, IWebHostEnvironment hostEnvironment)
        {
            this.playersService = playersService;
            this.hostEnvironment = hostEnvironment;
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

            string fileExtn = Path.GetExtension(input.ProfileImage.FileName);
            if (fileExtn != ".jpg")
            {
                await this.Response.WriteAsync("Select jpg format for the picture!");
                return this.View(input);
            }

            string uniqueFileName = this.UploadFile(input.ProfileImage);
            await this.playersService.Register(input.Name, input.Age, input.Height, input.Kilos, input.Number, input.PositionType, id, uniqueFileName);
            return this.Redirect("/Teams/Details");
        }

        public IActionResult All(int id)
        {
            var viewModel = new DetailsAllPlayers();
            var players = this.playersService.AllPlayersByTeamId<DetailsPlayer>(id);
            viewModel.Players = players;
            return this.View(viewModel);
        }

        public IActionResult Info(int id)
        {
            var playerViewModel = this.playersService.PlayersInfo<DetailsPlayer>(id);
            return this.View(playerViewModel);
        }

        public async Task<IActionResult> Remove(int id)
        {

            await this.playersService.Remove(id);
            return this.Redirect("/Teams/Details");
        }

        private string UploadFile(IFormFile profileImage)
        {
            string uniqueFileName = null;

            if (profileImage != null)
            {
                string uploadsFolder = Path.Combine(this.hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + " " + profileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                profileImage.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}
