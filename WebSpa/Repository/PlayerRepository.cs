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
        private readonly PlayerContext _playerContext;

        public PlayerRepository(PlayerContext context)
        {
            _playerContext = context;
        }

        public void AddPlayer(PlayerModel player)
        {
            var temp = _playerContext.Set<PlayerModel>();
            temp.Add(new PlayerModel
            {
                FirstName = player.FirstName,
                LastName = player.LastName
            });
            _playerContext.SaveChanges();
        }

        public async void DeletePlayer(int playerId)
        {
            PlayerModel playerModel = await _playerContext.Player.FindAsync(playerId);
            _playerContext.Player.Remove(playerModel);
            _playerContext.SaveChanges();
        }

        public IEnumerable<PlayerModel> GetAllPlayers()
        {
            return _playerContext.Player;
        }

        public async Task<PlayerModel> GetPlayerById(int playerId)
        {
            PlayerModel model = await _playerContext.Player.FindAsync(playerId);
            return model;
        }

        public void Save()
        {
            _playerContext.SaveChanges();
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
                    _playerContext.Dispose();
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