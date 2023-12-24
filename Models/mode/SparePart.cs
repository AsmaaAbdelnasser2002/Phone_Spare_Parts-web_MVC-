using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.mode;

public partial class SparePart
{
    public int SId { get; set; }

    public string? SName { get; set; }

    public string? Describtion { get; set; }
    public double? price { get; set; }

    public int? CId { get; set; }
    [NotMapped]
    public IFormFile clientFile { get; set; }
    public byte[]? Photo { get; set; }

    public virtual Catagory? CIdNavigation { get; set; }

  

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

   
}
