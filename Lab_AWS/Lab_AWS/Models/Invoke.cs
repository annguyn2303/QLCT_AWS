using System;
using System.Collections.Generic;

namespace Lab_AWS.Models;

public partial class Invoke
{
    public string IdInvoke { get; set; } = null!;

    public DateTime? Datetime { get; set; }

    public string IdStaff { get; set; } = null!;

    public string IdProduct { get; set; } = null!;

    public int? Quantity { get; set; }

    public bool? Status { get; set; }
}
