using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballManager.Services.Data
{
    public interface IMyTeamService
    {
         Task CreateMyTeam(string name, string coach, string owner, string userId);

         IEnumerable<T> GetAllTeamsById<T>(string userId);
    }
}
