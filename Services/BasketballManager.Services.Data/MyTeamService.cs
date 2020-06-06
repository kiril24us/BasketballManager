namespace BasketballManager.Services.Data
{
    using System.Threading.Tasks;

    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;

    public class MyTeamService : IMyTeamService
    {
        private readonly IDeletableEntityRepository<MyTeam> myTeamRepository;

        public MyTeamService(IDeletableEntityRepository<MyTeam> myTeamRepository)
        {
            this.myTeamRepository = myTeamRepository;
        }

        public async Task CreateMyTeam(string name, string coach, string owner)
        {
            var team = new MyTeam
            {
                Name = name,
                Owner = owner,
                Coach = coach,
            };

            await this.myTeamRepository.AddAsync(team);
        }
    }
}
