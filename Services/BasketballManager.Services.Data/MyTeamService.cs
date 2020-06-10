namespace BasketballManager.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AutoMapper;
    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class MyTeamService : IMyTeamService
    {
        private readonly IDeletableEntityRepository<MyTeam> myTeamRepository;

        public MyTeamService(
            IDeletableEntityRepository<MyTeam> myTeamRepository)
        {
            this.myTeamRepository = myTeamRepository;
        }

        public async Task<int> CreateMyTeam(string name, string coach, string owner, string userId)
        {
            var team = new MyTeam
            {
                Name = name,
                Coach = coach,
                Owner = owner,
                UserId = userId,
            };

            await this.myTeamRepository.AddAsync(team);
            await this.myTeamRepository.SaveChangesAsync();
            return team.Id;
        }

        public IEnumerable<T> GetAllTeamsById<T>(string userId)
        {
            var teams = this.myTeamRepository.All().Where(x => x.UserId == userId);

            return teams.To<T>().ToList();
        }
    }
}
