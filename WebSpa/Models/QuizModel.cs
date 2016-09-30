using System;

namespace WebSpa.Models
{
    public class QuizModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int MaxPoints { get; set; }
    }
}