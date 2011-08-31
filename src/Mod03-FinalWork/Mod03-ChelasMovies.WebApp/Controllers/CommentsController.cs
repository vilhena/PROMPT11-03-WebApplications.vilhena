using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.WebApp.Models;

namespace Mod03_ChelasMovies.WebApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService _CommentsService;
        private readonly IMoviesService _moviesService;
        private readonly IUserService _userService;

        public CommentsController(ICommentsService commentsService, IMoviesService moviesService, IUserService userService)
        {
            _CommentsService = commentsService;
            _moviesService = moviesService;
            _userService = userService;
        }

        //
        // GET: /Comments/

        public ActionResult Index(int movieId)
        {
            var comment = _CommentsService.Search("Movie.Id = " + movieId, 0, 0, "");

            return View(new CommentsModel()
            {
                MovieID = movieId
            });
        }

        //
        // GET: /Comments/Details/5

        public ActionResult Details(int id)
        {
            var comment = _CommentsService.Get(id);
            return View(new CommentsModel()
            {
                MovieID = comment.Movie.ID,
                ID = comment.ID,
                Description = comment.Description,
                Rating = comment.Rating,
                LastUpdated = comment.LastUpdated
            });
        }

        //
        // GET: /Comments/Create

        public ActionResult Create(int movieId)
        {
            var newComment = new CommentsModel()
            {
                MovieID = movieId
            };
            return View(newComment);
        } 

        //
        // POST: /Comments/Create

        [HttpPost]
        public ActionResult Create(CommentsModel c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newComment = new Comment();
                    TryUpdateModel(newComment);
                    Movie movie = _moviesService.Get(c.MovieID);
                    newComment.Movie = movie;
                    newComment.Owner = _userService.GetAuthenticatedUser(User.Identity.Name);
                    _CommentsService.Add(newComment);

                    return RedirectToRoute("Default", new { controller = "Movies" , action = "Details", id = c.MovieID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return View(c);
        }
        
        //
        // GET: /Comments/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Comments/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Comments/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Comments/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
