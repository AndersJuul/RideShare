using System;
using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Models
{
    public class Car
    {
        [Key]
        public Guid CarId { get; set; }

        [Required]
        public Event Event { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Email { get; set; }
    }
}