using System;
using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Models
{
    public class Car
    {
        [Key] public Guid CarId { get; set; }

        [Required] public Guid EventId { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Phone { get; set; }
    }
}