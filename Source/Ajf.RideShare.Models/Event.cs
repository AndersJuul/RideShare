using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string OwnerUserId { get; set; }
        [Required]
        public DateTime TimeFrom { get; set; }
        [Required]
        public DateTime TimeTo { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public ICollection<Car> Cars { get; set; }
        [Required]
        public ICollection<Passenger> Passengers { get; set; }
    }
}