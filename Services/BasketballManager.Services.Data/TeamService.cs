namespace BasketballManager.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class TeamService : ITeamService
    {
        private readonly IDeletableEntityRepository<Team> myTeamRepository;

        public TeamService(
            IDeletableEntityRepository<Team> myTeamRepository)
        {
            this.myTeamRepository = myTeamRepository;
        }

        public async Task<int> CreateMyTeam(string name, string coach, string owner, string userId)
        {
            var team = new Team
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
            var teams = this.myTeamRepository.All().Where(x => x.UserId == userId)
                                                   .OrderBy(x => x.Name);

            return teams.To<T>().ToList();
        }
    }
}
