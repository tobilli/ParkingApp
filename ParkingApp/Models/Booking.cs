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

    }
}
