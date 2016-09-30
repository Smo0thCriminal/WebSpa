using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using WebSpa.Models;

namespace WebSpa.Repository
{
    public class QuizRepository : IQuizRepository, IDisposable
    {
        private readonly WebSpaContext _context;

        public QuizRepository(WebSpaContext context)
        {
            _context = context;
        }
        public IEnumerable<QuizModel> GetQuizQuestions()
        {
            return _context.Quiz;
        }
        public async void DeleteQuestion(int quizId)
        {
            QuizModel quizModel = await _context.Quiz.FindAsync(quizId);
            _context.Quiz.Remove(quizModel);
            _context.SaveChanges();
        }
        public async Task<QuizModel> GetQuestionById(int quizId)
        {
            QuizModel model = await _context.Quiz.FindAsync(quizId);
            return model;
        }
        public void AddQuiz(QuizModel quiz)
        {
            var customers = _context.Set<QuizModel>();
            if (quiz == null) return;
            customers.Add(new QuizModel { Question = quiz.Question, Answer = quiz.Answer, MaxPoints = quiz.MaxPoints });

            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateQuiz(QuizModel quiz)
        {

        }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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