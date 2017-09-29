namespace Ajf.RideShare.Web.Models.ViewModels.Home
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string OwnerUserId { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string CreateTime { get; set; }
        //public ICollection<Car> Cars { get; set; }
        //public ICollection<Passenger> Passengers { get; set; }
    }
}