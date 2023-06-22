using System;
using System.Collections.Generic;

namespace Lab_AWS.Models;

public partial class Company
{
    public string IdCompany { get; set; } = null!;

    public string? Name { get; set; }

    public string? Contact { get; set; }
}
