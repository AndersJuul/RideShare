using System;

namespace Ajf.RideShare.Web.Models
{
    public class CreateCarForEventViewModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}