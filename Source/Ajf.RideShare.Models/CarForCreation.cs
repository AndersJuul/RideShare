using System;

namespace Ajf.RideShare.Models
{
    public class CarForCreation
    {
        public Guid EventId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}