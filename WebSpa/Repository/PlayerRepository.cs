using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebSpa.Models;

namespace WebSpa.Repository
{
    public class PlayerRepository : IPlayerRepository, IDisposable
    {
        private readonly WebSpaContext _сontext;

        public PlayerRepository(WebSpaContext context)
        {
            _сontext = context;
        }

        public void AddPlayer(PlayerModel player)
        {
            if (player == null) return;
            var temp = _сontext.Set<PlayerModel>();
            temp.Add(new PlayerModel
            {
                FirstName = player.FirstName,
                LastName = player.LastName
            });
            _сontext.SaveChanges();
        }

        public async void DeletePlayer(int playerId)
        {
            PlayerModel playerModel = await _сontext.Player.FindAsync(playerId);
            _сontext.Player.Remove(playerModel);
            _сontext.SaveChanges();
        }

        public IEnumerable<PlayerModel> GetAllPlayers()
        {
            return _сontext.Player;
        }

        public async Task<PlayerModel> GetPlayerById(int playerId)
        {
            PlayerModel model = await _сontext.Player.FindAsync(playerId);
            return model;
        }

        public void Save()
        {
            _сontext.SaveChanges();
        }

        public void UpdatePlayer(PlayerModel player)
        {
            
        }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _сontext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}