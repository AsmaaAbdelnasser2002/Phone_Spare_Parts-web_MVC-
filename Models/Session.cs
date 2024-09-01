using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceAPI2.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionId { get; set; }

        [StringLength(255)]
        public string SessionPlace { get; set; }

        [StringLength(100)]
        public string SessionDescription { get; set; }

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

        [ForeignKey("Sequance")]
        public int? Sequance_Id { get; set; }
        public virtual Sequance? Sequance { get; set; }
        public virtual List<AttendanceRecord>? AttendanceRecords { get; set; }

    }
}