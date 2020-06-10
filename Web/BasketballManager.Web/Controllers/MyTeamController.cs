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
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class MyTeamController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMyTeamService myTeamService;

        public MyTeamController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMyTeamService myTeamService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.myTeamService = myTeamService;
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
            await this.myTeamService.CreateMyTeam(input.Name, input.Coach, input.Owner, userId);
            return this.RedirectToAction("Details");
        }

        [Authorize]
        public IActionResult Details()
        {
            var userId = this.userManager.GetUserId(this.User);
            var viewModel = new DetailsMyTeamsViewModel();
            var teams = this.myTeamService.GetAllTeamsById<MyTeamViewModel>(userId);
            viewModel.Teams = teams;
            return this.View(viewModel);
        }
    }
}
