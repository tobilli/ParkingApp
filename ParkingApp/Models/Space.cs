using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingApp.Models
{
    public class Space
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        [Required]
        public string? Local_Govt { get; set; }
        public string Status { get; set; }
        [Required]
        public int No_Slot { get; set; }

        /* public string? Location_Img { get; set; }

         [NotMapped]
         public IFormFile ImageFile { get; set; }*/

        [Required]
        public DateTime Open_Time { get; set; }
        [Required]
        public DateTime Close_Time { get; set; }

       /* [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }*/

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }


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
