using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSpa.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PointsPerSession { get; set; }
        public bool TrueDeveloper { get; set; }
    }
}