namespace BasketballManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGamesService
    {
        Task RegisterGame(int teamId, int opponentId, int myPoints, int opponentPoints, DateTime date);

        IEnumerable<T> DetailsGames<T>(int id);

        IEnumerable<T> Proba<T>(string id);

        IEnumerable<T> DetailsAllGames<T>(string id);
    }
}
