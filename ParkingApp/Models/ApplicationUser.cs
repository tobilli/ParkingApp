using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace ParkingApp.Models
{
    public class ApplicationUser: IdentityUser// extend to the base class, identity user
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string? FullName { get; set; }
    }
}
