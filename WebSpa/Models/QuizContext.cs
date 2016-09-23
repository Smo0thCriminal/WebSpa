using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebSpa.Models
{
    public class QuizContext : DbContext
    {
        public QuizContext() : base("name=WebSpaDb")
        {}

        public DbSet<QuizModel> Quiz { get; set; }
    }
}