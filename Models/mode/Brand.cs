using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.mode;

public partial class Brand
{
    public int BId { get; set; }

    public string? BName { get; set; }

    public string? Country { get; set; }
    [NotMapped]
    public IFormFile clientFile { get; set; }
    public byte[]? Photo { get; set; }

    public virtual ICollection<Catagory> Catagories { get; set; } = new List<Catagory>();
}
