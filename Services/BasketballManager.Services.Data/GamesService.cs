namespace BasketballManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;

        public GamesService(IDeletableEntityRepository<Game> gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public IEnumerable<T> DetailsGames<T>(int id)
        {
            var games = this.gameRepository.All().Where(x => x.TeamId == id)
                                                 .OrderByDescending(x => x.Date);
            return games.To<T>().ToList();
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
    }
}
