namespace BasketballManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;
    using BasketballManager.Web.ViewModels.Games;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IDeletableEntityRepository<Team> teamRepository;

        public GamesService(
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Team> teamRepository)
        {
            this.gameRepository = gameRepository;
            this.teamRepository = teamRepository;
        }

        public IEnumerable<T> DetailsGames<T>(int id)
        {
            var games = this.gameRepository.All().Where(x => x.TeamId == id)
                                                 .OrderByDescending(x => x.Date);

            return games.To<T>().ToList();
        }

        public IEnumerable<T> DetailsAllGames<T>(string id)
        {
            var games = this.teamRepository.All().Where(x => x.UserId == id && x.IsManaged == true)
                                                  .GroupJoin(
                                                       this.gameRepository.All(),
                                                       t => t.Id,
                                                       g => g.TeamId,
                                                       (t, g) => new
                                                       {
                                                           TeamName = t.Name,
                                                           Games = g,
                                                       });

            var games3 = this.teamRepository.All().Where(x => x.UserId == id && x.IsManaged == true)
                                                  .GroupJoin(
                                                       this.gameRepository.All(),
                                                       t => t.Id,
                                                       g => g.TeamId,
                                                       (t, g) => new
                                                       {
                                                           Team = t.Name,
                                                           Games = g,
                                                           //Team = g.Team,
                                                           //Opponent = g.Opponent,
                                                           //OpponentId = g.OpponentId,
                                                           //MyPoints = g.MyPoints,
                                                           //OpponentPoints = g.OpponentPoints,
                                                           //Date = g.Date,
                                                       });
                                                  


            var g2 = from t in this.teamRepository.All()
                     join g in this.gameRepository.All()
                     on t.Id equals g.TeamId
                     into gamesGroup
                     select new
                     {
                         tName = t.Name,
                         g2 = gamesGroup,
                     };


            return games3.To<T>().ToList();
        }

        public async Task RegisterGame(int teamId, int opponentId, int myPoints, int opponentPoints, DateTime date)
        {
            var game = new Game
            {
                TeamId = teamId,
                OpponentId = opponentId,
                MyPoints = myPoints,
                OpponentPoints = opponentPoints,
                Date = date,
            };

            await this.gameRepository.AddAsync(game);
            await this.gameRepository.SaveChangesAsync();
        }

        public IEnumerable<T> Proba<T>(string id)
        {
            var games = this.teamRepository.All().Where(x => x.UserId == id && x.IsManaged == true)
                                                  .Join(
                                                       this.gameRepository.All(),
                                                       t => t.Id,
                                                       g => g.TeamId,
                                                       (t, g) => g)
                                                  .OrderBy(g => g.TeamId);
            return games.To<T>().ToList();
        }
    }
}
