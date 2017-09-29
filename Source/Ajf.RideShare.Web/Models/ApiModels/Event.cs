using System;

namespace Ajf.RideShare.Web.Models.ApiModels
{
    public class Event
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string OwnerUserId { get; set; }

        public DateTime TimeFrom { get; set; }

        public DateTime TimeTo { get; set; }

        public DateTime CreateTime { get; set; }
    }
}