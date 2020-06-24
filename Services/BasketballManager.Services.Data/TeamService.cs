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
        private readonly IDeletableEntityRepository<Team> teamRepository;

        public TeamService(
            IDeletableEntityRepository<Team> teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public async Task<int> CreateMyTeam(string name, string coach, string owner, string userId, bool isManaged)
        {
            var team = new Team
            {
                Name = name,
                Coach = coach,
                Owner = owner,
                UserId = userId,
                IsManaged = isManaged,
            };

            await this.teamRepository.AddAsync(team);
            await this.teamRepository.SaveChangesAsync();
            return team.Id;
        }

        public IEnumerable<T> GetAllTeamsById<T>(string userId)
        {
            var teams = this.teamRepository.All().Where(x => x.UserId == userId)
                                                   .OrderBy(x => x.CreatedOn);

            return teams.To<T>().ToList();
        }
    }
}
