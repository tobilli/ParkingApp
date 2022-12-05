using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ParkingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public string License_No { get; set; }
        [Required]
        public string Vehicle_Type { get; set; }
        [Required]
        public DateTime Date_Arrival { get; set; }
        [Required]
        public DateTime Date_Depature { get; set; }                

        [Required]
        public string Area { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }
        [Required]
        public DateTime Open_Time { get; set; }
        [Required]
        public DateTime Close_Time { get; set; }

        [Column(TypeName = "Money")]
        public decimal Daily_Parking { get; set; }

        [Column(TypeName = "Money")]
        public decimal Weekly_Parking { get; set; }

        [Column(TypeName = "Money")]
        public decimal Monthly_Parking { get; set; }

        [Required]
        [MaxLength(160)]
        public string? Parking_Desc { get; set; }

    }
}
