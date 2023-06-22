using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_AWS.Models;

public partial class Truckdetail
{
    public string IdTruck { get; set; } = null!;

    public string IdProduct { get; set; } = null!;

    public int? Inventory { get; set; }

    public int? Used { get; set; }

    [ForeignKey(nameof(IdProduct))]
    public Product product { get; set; }
}
