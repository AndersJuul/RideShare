using System;
using System.ComponentModel.DataAnnotations;
using Highway.Data;

namespace Ajf.RideShare.Models
{
    public class Car : IIdentifiable<Guid>
    {
        [Key] public Guid CarId { get; set; }

        [Required] public Guid EventId { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Phone { get; set; }
        public Guid Id
        {
            get => CarId;
            set => CarId=value;
        }
    }
}