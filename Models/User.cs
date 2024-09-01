using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceAPI2.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100)]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "please enter correct email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "The Password must be at least 8 characters long.", MinimumLength = 8)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\(?([0-9]{11})$",ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^(Instructor|Attender|Admin)$", ErrorMessage = "Invalid user role. Valid roles are 'Instructor', 'Attender', 'Admin'.")]
        //Instructor or Attender or Admin
        public string UserRole { get; set; }

        public virtual List<AttendanceRecord> AttendanceRecords { get; set; }
        public virtual List<Package> Packages { get; set; }
        public virtual List<Sequance> Sequances { get; set; }
        public virtual List<Session> Sessions { get; set; }
    }
}