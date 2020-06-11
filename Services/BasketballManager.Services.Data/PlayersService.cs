using BasketballManager.Data.Common.Models;
using BasketballManager.Data.Common.Repositories;
using BasketballManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManager.Services.Data
{
    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<Player> playersRepository;

        public PlayersService(IDeletableEntityRepository<Player> playersRepository)
        {
            this.playersRepository = playersRepository;
        }

        public async Task Register(string name, int age, double height, double kilos, int number, string positionType, int myTeamId)
        {
            var positionAsEnum = Enum.Parse<PositionType>(positionType);

            var player = new Player
            {
                Name = name,
                Age = age,
                Height = height,
                Kilos = kilos,
                Number = number,
                PositionType = positionAsEnum,
                MyTeamId = myTeamId,
            };

            await this.playersRepository.AddAsync(player);
            await this.playersRepository.SaveChangesAsync();
        }

        public 
    }
}
