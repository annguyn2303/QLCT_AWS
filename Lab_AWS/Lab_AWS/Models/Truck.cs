using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_AWS.Models;

public partial class Truck
{
    public string IdTruck { get; set; } = null!;

    public string LicensePlates { get; set; } = null!;

    public string IdStaff { get; set; } = null!;

    public bool Status { get; set; }

    [ForeignKey(nameof(IdStaff))]
    public Staff staff { get; set; }
}
