namespace BasketballManager.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BasketballManager.Data;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Data;
    using BasketballManager.Services.Mapping;
    using BasketballManager.Web.ViewModels.MyTeam;
    using BasketballManager.Web.ViewModels.Teams;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITeamService teamService;

        public TeamsController(
            UserManager<ApplicationUser> userManager,
            ITeamService teamService)
        {
            this.userManager = userManager;
            this.teamService = teamService;
        }

        [Authorize]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterMyTeamViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.teamService.CreateMyTeam(input.Name, input.Coach, input.Owner, userId, input.IsManaged);
            return this.Redirect("Details");
        }

        [Authorize]
        public IActionResult Details()
        {
            var userId = this.userManager.GetUserId(this.User);
            var viewModel = new DetailsMyTeamsViewModel();
            var teams = this.teamService.GetMyTeamsById<MyTeamViewModel>(userId);
            viewModel.Teams = teams;
            return this.View(viewModel);
        }
    }
}
