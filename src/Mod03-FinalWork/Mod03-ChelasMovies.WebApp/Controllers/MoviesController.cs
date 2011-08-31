using System;
using System.Web.Mvc;
using Mod03_ChelasMovies.DomainModel;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IUserService _userService;
        
        public MoviesController(IMoviesService moviesService, IUserService userService)
        {
            _moviesService = moviesService;
            _userService = userService;
        }

        //
        // GET: /Movies/
        public ActionResult Index()
        {
            return View(_moviesService.GetMyMovies(User.Identity.Name));
        }


        public ActionResult Details(int id)
        {

            Movie movie = _moviesService.GetWithComments(id);
            if(movie == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound", id);
            }
            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(string Title, string fill)
        {

            if (!string.IsNullOrEmpty(fill))
            {
                return View(_moviesService.Search(Title));
            }

            var newMovie = new Movie();
            TryUpdateModel(newMovie);
            if (ModelState.IsValid)
            {
                newMovie.Owner = _userService.GetAuthenticatedUser(User.Identity.Name);
                _moviesService.Add(newMovie);
                return RedirectToAction("Details", new { id = newMovie.ID });
            }
            else
            {
                return View(newMovie);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_moviesService.Get(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id, string fill)
        {
            var oldMovie = _moviesService.Get(id);
            TryUpdateModel(oldMovie);
            ModelState.Clear();

            if (!string.IsNullOrEmpty(fill))
            {
                _moviesService.Fill(oldMovie);
                return View(oldMovie);
            }

            if (ModelState.IsValid)
            {
                _moviesService.Update(oldMovie);
                return RedirectToAction("Details", new {id = id});
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Movie movie = _moviesService.Get(id);
            if (movie == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound", id);
            }
            else
            {
                _moviesService.Delete(id);
            }
            return RedirectToAction("Index", new { });
        }

        public ActionResult CreateComment(int movieId)
        {
            Comment c = new Comment {Movie = _moviesService.Get(movieId)};
            return View(c);
        }

        [HttpPost]
        public ActionResult CreateComment(Comment c)
        {
            try
            {
                if (ModelState.IsValid) {
                    Movie movie = _moviesService.Get(c.Movie.ID);
                    c.Movie = movie;
                    movie.Comments.Add(c);
                    c.Owner = _userService.GetAuthenticatedUser(User.Identity.Name);
                    _moviesService.Update(movie);
                    return RedirectToRoute("Default", new { action = "Details", id = c.Movie.ID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return View(c);
        }


        public ActionResult DeleteComment(int movieid, int id)
        {
            _moviesService.DeleteComment(movieid, id);
            return RedirectToAction("Edit", new { id = movieid});
        }
    }
}
