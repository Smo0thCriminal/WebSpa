using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSpa.Models;

namespace WebSpa.Repository
{
    interface IQuizRepository : IDisposable
    {
        IEnumerable<QuizModel> GetQuizQuestions();
        Task<QuizModel> GetQuestionById(int quizId);
        void AddQuiz(QuizModel quiz);
        void DeleteQuestion(int quizId);
        void UpdateQuiz(QuizModel quiz);
        void Save();
    }
}
