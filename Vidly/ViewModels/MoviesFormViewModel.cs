using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MoviesFormViewModel
	{
		public int? Id { get; set; }

		[Required(ErrorMessage = "Please enter movies's name")]
		[StringLength(255)]
		public string Name { get; set; }

		[Display(Name = "Release Date")]
		[Required(ErrorMessage = "Please enter the Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Display(Name = "Date Added")]
		[Required(ErrorMessage = "Please enter the Date Added")]
		public DateTime? DateAdded { get; set; }

		[Required(ErrorMessage = "Please select the Genre")]
		[Display(Name = "Genre")]
		public int? GenreId { get; set; }

		[Required(ErrorMessage = "The number in stock is required")]
		[Range(1, 20, ErrorMessage = "The value must be betwen 1-20")]
		[Display(Name = "Number in Stock")]
		public int? NumberInStock { get; set; }

		public IEnumerable<Genre> GebreTypes { get; set; }
		public string Title => Id != 0 ? "Edit Movie" : "New Movie";

		public MoviesFormViewModel()
		{
			Id = 0;
		}

		public MoviesFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			DateAdded = movie.DateAdded;
			NumberInStock = movie.NumberInStock;
			GenreId = movie.GenreId;
		}
	}
}