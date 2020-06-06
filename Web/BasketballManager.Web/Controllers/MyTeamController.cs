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
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public MyTeamController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterMyTeamViewModel input)
        {
            //var team = this.db.MyTeams.To<MyTeam>(input).FirstOrDefault();

            //var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            //var userId = user.Id;

            var team = new MyTeam
            {
                Name = input.Name,
                Coach = input.Coach,
                Owner = input.Owner,
                //UserId = userId,
            };

            this.db.MyTeams.Add(team);
            this.db.SaveChanges();
            return this.Redirect("/");
        }

        public IActionResult Details()
        {
            var viewModel = new DetailsMyTeamsViewModel();
            //var teams = this.db.MyTeams.To<DetailsMyTeamsViewModel>().ToList();
            var teams = this.db.MyTeams.Select(a => new MyTeamViewModel
            {
                Name = a.Name,
            }).ToList();
            viewModel.Teams = teams;
            return this.View(viewModel);
        }
    }
}
