namespace BasketballManager.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using BasketballManager.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class MyTeamsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.MyTeams.Any())
            {
                return;
            }

            var myteam = new MyTeam
                {
                    Name = "Los Angeles Lakers",
                    Coach = "Frank Vogel",
                    Owner = "Jessie",
                };

            await dbContext.MyTeams.AddAsync(myteam);
        }
    }
}
