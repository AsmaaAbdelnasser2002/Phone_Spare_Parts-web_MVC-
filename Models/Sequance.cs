using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceAPI2.Models
{
    public class Sequance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SequanceId { get; set; }

        [Required]
        [StringLength(100)]
        public string SequanceName { get; set; }

        [StringLength(250)]
        public string SequanceDescription { get; set; }

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

        [ForeignKey("Package")]
        public int? Package_Id { get; set; }
        public virtual Package? Package { get; set; }
        public virtual List<Session>? Session { get; set; }
    }
}