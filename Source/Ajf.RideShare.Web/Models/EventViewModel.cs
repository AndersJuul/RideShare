using System;

namespace Ajf.RideShare.Web.Models
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public ViewModelMode ViewModelMode { get; set; }
        public string CarName { get; set; }
        public string CarPhone { get; set; }
        public string CarEmail { get; set; }
    }
}