using System;
using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Models
{
    public class EventForCreation
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
    }
}