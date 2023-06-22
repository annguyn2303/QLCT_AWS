using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_AWS.Models;

public partial class Product
{
    public string IdProduct { get; set; } = null!;

    public string IdCompany { get; set; } = null!;

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? MaxQuantity { get; set; }

    public bool Status { get; set; }

    [ForeignKey(nameof(IdCompany))]
    public Company company { get; set; }
}
