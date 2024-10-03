using System;
using System.Collections.Generic;

namespace WebApi.Sample.Models;

public partial class UserDetail
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public bool IsActive { get; set; }
}
