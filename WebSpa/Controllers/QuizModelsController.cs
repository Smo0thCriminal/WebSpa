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
    public class QuizModelsController : ApiController
    {
        private readonly IQuizRepository _quizRepository;

        public QuizModelsController()
        {
            _quizRepository = new QuizRepository(new WebSpaContext());
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