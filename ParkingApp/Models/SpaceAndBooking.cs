using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ParkingApp.Models
{
    public class SpaceAndBooking
    {
        public int Id { get; set; } 
        // this is for space stuff you want to show on the frontend
        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        public string Status { get; set; } = string.Empty;
        public string ParkingDesc { get; set; } = string.Empty;

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

        // add the rest of the booking stuff below
        public string License_No { get; set; } = string.Empty;
        
        [Required]
        public string Vehicle_Type { get; set; } = string.Empty;
        [Required]
        public DateTime Date_Arrival { get; set; } 
        [Required]
        public DateTime Date_Depature { get; set; }

        public decimal Total_Amount { get; set; }
    }
}
