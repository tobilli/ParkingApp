using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Models;

namespace ParkingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<ParkingApp.Models.Space> spaces { get; set; }

        public DbSet<ParkingApp.Models.Bookings> bookings { get; set; }
    }
}