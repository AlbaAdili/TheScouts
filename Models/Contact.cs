using System;
using System.ComponentModel.DataAnnotations;
namespace TheScouts.Models
{
	public class Contact
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required.")]
		[Display(Name = "Name")]
		public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
	}
}

