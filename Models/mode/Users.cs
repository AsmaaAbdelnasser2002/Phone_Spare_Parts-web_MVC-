using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.mode;
public partial class Users
{
    [Display(Name = "UId")]
    public int UId { get; set; }


    [Required(ErrorMessage ="Please Enter Your First Name")]
    [Display(Name = "FName")]
    [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]

    public string FName { get; set; } = null!;

    [Required(ErrorMessage = "Please Enter Your Last Name")]
    [Display(Name = "LName")]
    [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]

    public string LName { get; set; } = null!;


    [Required(ErrorMessage = "Please Enter Your Email ")]
	[RegularExpression(".+@.+\\..+",ErrorMessage ="please enter correct email address")]
    [Display(Name = "EMail")]
    public string EMail { get; set; } = null!;

   
    [Required(ErrorMessage = "Please Enter Your Password ")]
    [Display(Name = "Pass")]
    [StringLength(50, ErrorMessage = "The Password must be at least 8 characters long.", MinimumLength = 8)]

    public string Pass { get; set; } = null!;


    [Required(ErrorMessage = "Please Enter Your Address ")]
    [Display(Name = "Addres")]
    public string Addres { get; set; } = null!;


    [Required(ErrorMessage = "Please Enter Your Phone ")]
    [RegularExpression(@"^\(?([0-9]{11})$",
    ErrorMessage = "Entered phone format is not valid.")]
    [Display(Name = " Phone")]
    public string Phone { get; set; } = null!;


    [Display(Name = "PankCode")]
    public string? PankCode { get; set; }
    [NotMapped]
    public IFormFile clientFile { get; set; }
    public byte[]? Photo { get; set; }

   

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
