using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceAPI2.Models
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }

        [Required]
        [StringLength(100)]
        public string PackageName { get; set; }

        [StringLength(250)]
        public string PackageDescription { get; set; }

        public byte[] Sheet { get; set; }

        [StringLength(250)]
        public string FacesFolder { get; set; }

        [StringLength(250)]
        public string VoicesFolder { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }
        public virtual List<Sequance>? Sequances { get; set; }
    }
}