using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
	public class MoviesDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter movies's name")]
		[StringLength(255)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter the Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Required(ErrorMessage = "Please enter the Date Added")]
		public DateTime DateAdded { get; set; }


		[Required(ErrorMessage = "Please select the GenreId")]
		public int GenreId { get; set; }
		public GenreDto Genre { get; set; }

		[Required(ErrorMessage = "The number in stock is required")]
		[Range(1, 20, ErrorMessage = "The value must be betwen 1-20")]
		public int NumberInStock { get; set; }
	}
}