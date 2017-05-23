using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public ViewResult Index()
		{
			//var movies = _context.Movies.Include(m => m.Genre).ToList();
			if (User.IsInRole(RoleName.CanManageMovies))
				return View("List");
			return View("ReadOnlyList");
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}

		[HttpPost]
		[Authorize(Roles = RoleName.CanManageMovies)]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MoviesFormViewModel(movie)
				{
					GebreTypes = _context.Genres.ToList()
				};
			}

			Movie updateMovie;
			if (movie.Id == 0)
			{
				_context.Movies.Add(movie);
				_context.SaveChanges();
				return RedirectToAction("Index", "Movies");
			}

			else
			{
				updateMovie = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

				updateMovie.NumberInStock = movie.NumberInStock;
				updateMovie.DateAdded = movie.DateAdded;
				updateMovie.GenreId = movie.GenreId;
				updateMovie.Name = movie.Name;
				updateMovie.ReleaseDate = movie.ReleaseDate;
				_context.SaveChanges();
				return RedirectToAction("Details", "Movies", new { id = updateMovie.Id });
			}
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var viewModel = new MoviesFormViewModel() { GebreTypes = genres };
			return View("MoviesForm", viewModel);
		}
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
			if (movie != null)
			{
				var genre = _context.Genres.ToList();
				var viewModel = new MoviesFormViewModel(movie) { GebreTypes = genre };
				return View("MoviesForm", viewModel);
			}
			return HttpNotFound();
		}

		// GET: Movies/Random
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "Shrek!" };
			var customers = new List<Customer>
			{
				new Customer {Name="Customer 1"},
				new Customer {Name="Customer 2"}
			};
			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers

			};
			return View(viewModel);
			//return Content("Hello World");
			//return HttpNotFound();
			//return new EmptyResult();
			//return RedirectToAction("Index","Home",new {page = 1, sortBy = "name"});
		}


		// movies
		public ActionResult Index1(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;
			if (String.IsNullOrWhiteSpace(sortBy))
				sortBy = "Name";
			return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
		}
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

		//applying constrains to the attributes (you can apply more than one)
		[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")] //other constrains you can apply(min,max,minlength,maxlength,int,float,guid)
		public ActionResult ByReleaseYear(int year, int month)
		{
			return Content(year + "/" + month);
		}
	}
}