using System;
using System.ComponentModel.DataAnnotations;
namespace TheScouts.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Name is required.")]
		[Display(Name = "Name")]
		public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "User Role")]
        public string UserRole { get; set; } = "User";
	}
}

