using System;
using System.Collections.Generic;

namespace Lab_AWS.Models;

public partial class Staff
{
    public string IdStaff { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Status { get; set; }
}
