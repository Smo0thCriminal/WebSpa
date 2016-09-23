using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebSpa.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext() : base("name=WebSpaDb")
        { }

        public DbSet<PlayerModel> Player { get; set; }
    }
}