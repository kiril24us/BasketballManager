using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManager.Services.Data
{
    public interface IPlayersService
    {
        Task Register(string name, int age, double height, double kilos, int number, string positionType, int myTeamId);
    }
}
