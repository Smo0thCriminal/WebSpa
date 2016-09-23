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
        private readonly IPlayerRepository _repository;

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
