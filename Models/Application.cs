using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace TheScouts.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

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

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Resume")]
        public string? Resume { get; set; }

        public int PositionId { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Submitted";

        [ForeignKey("PositionId")]
        public virtual Position? Position { get; set; }

        public string? UserId { get; set; }
    }
}