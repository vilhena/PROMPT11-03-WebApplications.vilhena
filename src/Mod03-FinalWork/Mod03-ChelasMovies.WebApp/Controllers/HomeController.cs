using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mod03_ChelasMovies.DomainModel.Services;

namespace Mod03_ChelasMovies.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWallService _wallService;

        public HomeController(IWallService wallService)
        {
            _wallService = wallService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Chelas Movies!";

            return View(_wallService.GetMyWall(User.Identity.Name));
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
