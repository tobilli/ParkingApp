using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingApp.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        [Required]
        public string License_No { get; set; }
        [Required]
        public string Vehicle_Type { get; set; }
        [Required]
        public string Local_Govt { get; set; }
        [Required]
        public DateTime Date_Arrival { get; set; }
        [Required]
        public DateTime Date_Depature { get; set; }
        /*public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? ApplicationUser { get; set; }*/

        [Required]
        public int SpaceId { get; set; }

        [ForeignKey("SpaceId")]
        public virtual Space? Space { get; set; }
    }
}
