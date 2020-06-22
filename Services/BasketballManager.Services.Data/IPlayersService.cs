namespace BasketballManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPlayersService
    {
        Task Register(string name, int age, double height, double kilos, int number, string positionType, int teamId);

        IEnumerable<T> AllPlayersByTeamId<T>(int teamId);

        T PlayersInfo<T>(int playerId);

        Task Remove(int playerId);
    }
}
