using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebSpa.Models;
using WebSpa.Repository;

namespace WebSpa.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerRepository _repo;
        public HomeController()
        {
            _repo = new PlayerRepository(new WebSpaContext());
        }
        public ActionResult Index()
        {
            _repo.AddPlayer(new PlayerModel { FirstName = "123", LastName = "123" });
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
