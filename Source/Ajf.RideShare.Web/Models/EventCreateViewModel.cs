using System;

namespace Ajf.RideShare.Web.Models
{
    public class EventCreateViewModel
    {
        public DateTime Date { get; set; }
        public Guid EventId { get; set; }
        public string Description { get; set; }
    }
}