﻿namespace BasketballManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BasketballManager.Data.Common.Models;
    using BasketballManager.Data.Common.Repositories;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<Player> playersRepository;

        public PlayersService(IDeletableEntityRepository<Player> playersRepository)
        {
            this.playersRepository = playersRepository;
        }

        public IEnumerable<T> AllPlayersByTeamId<T>(int myteamId)
        {
            var players = this.playersRepository.All().Where(x => x.MyTeamId == myteamId)
                                                      .OrderBy(x => x.Name);
            return players.To<T>().ToList();
        }

        public T PlayersInfo<T>(int playerId)
        {
            var player = this.playersRepository.All().Where(x => x.Id == playerId);
            return player.To<T>().FirstOrDefault();
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
    }
}
