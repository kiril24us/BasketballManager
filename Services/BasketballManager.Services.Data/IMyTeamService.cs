using System.Threading.Tasks;

namespace BasketballManager.Services.Data
{
    public interface IMyTeamService
    {
         Task CreateMyTeam(string name, string coach, string owner);

         //T Get<T>(string name);
    }
}
