using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int NumberOfPassengerSeats { get; set; }
    }
}