using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.mode;

public partial class Order
{
    public int OId { get; set; }

    public int? SId { get; set; }

    public int? UId { get; set; }

    public DateTime? ODate { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual SparePart? SIdNavigation { get; set; }

    public virtual Users? UIdNavigation { get; set; }
}
