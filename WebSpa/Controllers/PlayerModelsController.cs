using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebSpa.Models;
using WebSpa.Repository;

namespace WebSpa.Controllers
{
    public class PlayerModelsController : ApiController
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerModelsController()
        {
            _playerRepository = new PlayerRepository(new WebSpaContext());
        }

        // GET: api/PlayerModels
        public IEnumerable<PlayerModel> GetPlayers()
        {
            return _playerRepository.GetAllPlayers();
        }

        // GET: api/PlayerModels/5
        [ResponseType(typeof(PlayerModel))]
        public async Task<IHttpActionResult> GetPlayerModel(int id)
        {
            PlayerModel playerModel = await _playerRepository.GetPlayerById(id);
            if (playerModel == null)
            {
                return NotFound();
            }

            return Ok(playerModel);
        }

        // PUT: api/PlayerModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerModel(int id, PlayerModel playerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerModel.Id)
            {
                return BadRequest();
            }

            _playerRepository.UpdatePlayer(playerModel);

            try
            {
                _playerRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerModelExists(id))
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PlayerModels
        [ResponseType(typeof(PlayerModel))]
        public IHttpActionResult PostPlayerModel(PlayerModel playerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _playerRepository.AddPlayer(playerModel);
            _playerRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = playerModel.Id }, playerModel);
        }

        // DELETE: api/PlayerModels/5
        [ResponseType(typeof(PlayerModel))]
        public async Task<IHttpActionResult> DeletePlayerModel(int id)
        {
            PlayerModel playerModel = await _playerRepository.GetPlayerById(id);
            if (playerModel == null)
            {
                return NotFound();
            }

            _playerRepository.DeletePlayer(id);
            _playerRepository.Save();

            return Ok(playerModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _playerRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerModelExists(int id)
        {
            return _playerRepository.GetAllPlayers().Count(e => e.Id == id) > 0;
        }
    }
}