using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSpa.Models;

namespace WebSpa.Repository
{
    interface IPlayerRepository : IDisposable
    {
        IEnumerable<PlayerModel> GetAllPlayers();
        Task<PlayerModel> GetPlayerById(int playerId);
        void AddPlayer(PlayerModel player);
        void DeletePlayer(int playerId);
        void UpdatePlayer(PlayerModel player);
        void Save();
    }
}
