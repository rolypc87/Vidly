using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
	    private ApplicationDbContext _context;

	    public MoviesController()
	    {
		    _context=new ApplicationDbContext();
	    }

		//Get /api/Movies
		[HttpGet]
		public IEnumerable<MoviesDto> GetMovies()
	    {
		    return _context.Movies.ToList().Select(Mapper.Map<Movie,MoviesDto>);
	    }

		//Get /api/Movies/1
	    [HttpGet]
	    public IHttpActionResult GetMovie(int id)
	    {
		    var movie = _context.Movies.SingleOrDefault(m=>m.Id==id);
		    if (movie == null)
			    return NotFound();
		    return Ok(Mapper.Map< Movie,MoviesDto>(movie));
	    }

		// Post /api/Movies
	    [HttpPost]
	    public IHttpActionResult CreateMovie(MoviesDto moviesDto)
	    {
		    if (!ModelState.IsValid)
			    return BadRequest();
		    var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);
		    _context.Movies.Add(movie);
		    _context.SaveChanges();
		    Mapper.Map(movie,moviesDto);
		    return Created(new Uri(Request.RequestUri + "/" + movie.Id),moviesDto );
	    }
		//Put /api/Movies/1
	    [HttpPut]
	    public void UpdateMovie(int id, MoviesDto moviesDto)
	    {
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			var movieInDb = _context.Movies.SingleOrDefault(m=>m.Id==id);
			if(movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
		    Mapper.Map(moviesDto,movieInDb);// i don't need to declare it like this(Mapper.Map<MoviesDto, Movie>(moviesDto,movieInDb)) because the compiler automaticaly maps this <MoviesDto, Movie> with the parameters
		    _context.SaveChanges();
	    }
		// DELETE /api/Movies/1
	    [HttpDelete]
	    public void DeleteMovie(int id)
	    {
		    var movieInDb = _context.Movies.SingleOrDefault(m=>m.Id==id);
			if(movieInDb==null)
				throw new HttpResponseException(HttpStatusCode.Found);
		    _context.Movies.Remove(movieInDb);
		    _context.SaveChanges();
	    }
    }
}
