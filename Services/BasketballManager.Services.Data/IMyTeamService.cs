﻿namespace BasketballManager.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMyTeamService
    {
         Task<int> CreateMyTeam(string name, string coach, string owner, string userId);

         IEnumerable<T> GetAllTeamsById<T>(string userId);
    }
}
