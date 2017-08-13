using System.ComponentModel.DataAnnotations;

namespace Ajf.RideShare.Models
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}