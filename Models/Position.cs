using System;
using System.ComponentModel.DataAnnotations;
namespace TheScouts.Models
{
	public class Position
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Country is required.")]
		[Display(Name = "Country")]
        [StringLength(30)]
        public string Country { get; set; }

		[Required(ErrorMessage = "City is required.")]
		[Display(Name = "City")]
        [StringLength(30)]
        public string City { get; set; }

		[Required(ErrorMessage = "Job Title is required.")]
		[Display(Name = "Job Title")]
		[StringLength(30)]
		public string JobTitle { get; set; }

		[Required(ErrorMessage = "Job Description is required.")]
		[Display(Name = "Job Description")]
        public string JobDescription { get; set; }
	}
}

