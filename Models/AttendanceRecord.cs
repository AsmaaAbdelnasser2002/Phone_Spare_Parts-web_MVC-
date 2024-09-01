using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceAPI2.Models
{
    public class AttendanceRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^(Present|Absent)$", ErrorMessage = "Invalid Status. Valid Status are 'Present', 'Absent'.")]

        public string Status { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Session")]
        public int Session_Id { get; set; }
        public virtual Session Session { get; set; }
    }
}