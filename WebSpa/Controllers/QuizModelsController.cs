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
using System.Web.Http.Results;
using WebSpa.Models;
using WebSpa.Repository;

namespace WebSpa.Controllers
{
    public class QuizModelsController : ApiController
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IQuizRepository _quizRepository;

        public QuizModelsController()
        {
            _quizRepository = new QuizRepository(new WebSpaContext());
            _playerRepository = new PlayerRepository(new WebSpaContext());
        }

        // GET: api/QuizModels
        public IEnumerable<QuizModel> GetQuiz()
        {
            return _quizRepository.GetQuizQuestions();
        }

        // GET: api/QuizModels/5
        [ResponseType(typeof(QuizModel))]
        public async Task<IHttpActionResult> GetQuizModel(int id)
        {
            QuizModel quizModel = await _quizRepository.GetQuestionById(id);
            if (quizModel == null)
            {
                return NotFound();
            }

            return Ok(quizModel);
        }

        [HttpGet]
        [Route("api/QuizModels/rand")]
        [ResponseType(typeof(QuizModel))]
        public IHttpActionResult GetRandomQuiz()
        {
            Random rand = new Random();
            List<QuizModel> list = new List<QuizModel>();
            var raw = _quizRepository.GetQuizQuestions().ToList();
            var maxId = raw.Max(x => x.Id);
            var minId = raw.Min(x => x.Id);
            foreach (var question in raw)
            {
                var randId = rand.Next(minId, maxId);
                if (raw.Any(x => x.Id == randId))
                {
                    list.Add(question);
                }
            }
            //if (list.Count >= 5)L
            return Ok(list);

            //return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/QuizModels/score")]
        //[ResponseType(typeof (QuizModel))]
        public IHttpActionResult GetPlayerScore(List<QuizModel> model)
        {
            if (model == null) return BadRequest();

            var raw = _quizRepository.GetQuizQuestions();
            int totalPoints = 0;
            string devTrue = "";
            foreach (var rawItem in raw)
            {
                foreach (var modelItem in model)
                {
                    if (modelItem.Answer == rawItem.Answer)
                    {
                        totalPoints += modelItem.MaxPoints;
                    }
                }
            }
            if (totalPoints > 150)
            {
                devTrue = "true";
            }
            else
            {
                devTrue = "false";
            }

            _playerRepository.UpdatePlayerScore(new PlayerModel(), totalPoints, devTrue);

            return Ok();
        }

        // PUT: api/QuizModels/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult UpdateQuizModel(int id, QuizModel quizModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quizModel.Id)
            {
                return BadRequest();
            }

            _quizRepository.UpdateQuiz(quizModel);

            try
            {
                _quizRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuizModels
        [ResponseType(typeof(QuizModel))]
        public IHttpActionResult PostQuizModel(QuizModel quizModel)
        {
            if (quizModel == null)
            {
                return BadRequest(ModelState);
            }

            _quizRepository.AddQuiz(quizModel);
            _quizRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = quizModel.Id }, quizModel);
        }

        // DELETE: api/QuizModels/5
        [ResponseType(typeof(QuizModel))]
        public async Task<IHttpActionResult> DeleteQuizModel(int id)
        {
            QuizModel quizModel = await _quizRepository.GetQuestionById(id);
            if (quizModel == null)
            {
                return NotFound();
            }

            _quizRepository.DeleteQuestion(id);
            _quizRepository.Save();

            return Ok(quizModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _quizRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}