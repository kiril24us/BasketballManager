namespace BasketballManager.Services.Data
{
    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;

    public class MyTeamService : IMyTeamService
    {
        private readonly IDeletableEntityRepository<MyTeam> myTeamRepository;

        public MyTeamService(IDeletableEntityRepository<MyTeam> myTeamRepository)
        {
            this.myTeamRepository = myTeamRepository;
        }

        public void CreateMyTeam(string name, string coach, string owner)
        {
            var team = new MyTeam
            {
                Name = name,
                Owner = owner,
                Coach = coach,
            };

            this.myTeamRepository.AddAsync(team);
        }
    }
}
