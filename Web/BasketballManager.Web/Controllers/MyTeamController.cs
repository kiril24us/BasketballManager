namespace BasketballManager.Web.Controllers
{
    using BasketballManager.Data;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Data;
    using BasketballManager.Web.ViewModels.MyTeam;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class MyTeamController : Controller
    {
        private readonly ApplicationDbContext db;

        public MyTeamController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterMyTeamViewModel input)
        {
            var team = new MyTeam
            {
                Name = input.Name,
                Coach = input.Coach,
                Owner = input.Owner,
            };

            this.db.MyTeams.Add(team);
            this.db.SaveChanges();
            return this.Redirect("/");
        }
    }
}
