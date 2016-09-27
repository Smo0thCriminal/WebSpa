using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebSpa.Models
{
    public class WebSpaContext : DbContext
    {
        public WebSpaContext() : base("name=WebSpaDb")
        {}

        public DbSet<QuizModel> Quiz { get; set; }
        public DbSet<PlayerModel> Player { get; set; } 
    }
}