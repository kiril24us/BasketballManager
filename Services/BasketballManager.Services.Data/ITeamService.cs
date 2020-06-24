namespace BasketballManager.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeamService
    {
         Task<int> CreateMyTeam(string name, string coach, string owner, string userId, bool isManaged);

         IEnumerable<T> GetAllTeamsById<T>(string userId);
    }
}
