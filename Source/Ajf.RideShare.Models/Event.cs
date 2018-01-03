using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Models
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ICollection<Car> Cars { get; set; }
    }
}