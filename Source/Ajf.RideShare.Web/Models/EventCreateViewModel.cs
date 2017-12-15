using System;
using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Web.Models
{
    public class EventCreateViewModel
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH.mm}")]
        public DateTime Date { get; set; }
        public Guid EventId { get; set; }
        public string Description { get; set; }
    }
}