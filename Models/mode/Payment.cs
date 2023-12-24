using System;
using System.Collections.Generic;

namespace WebApplication6.mode;

public partial class Payment
{
    public int PId { get; set; }

    public string PMethod { get; set; } = null!;

    public DateTime? PDate { get; set; }

    public double? TotalPrice { get; set; }

    public int? OId { get; set; }

    public virtual Order? OIdNavigation { get; set; }
}
