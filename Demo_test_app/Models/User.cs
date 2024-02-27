using System;
using System.Collections.Generic;

namespace Demo_test_app.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? FullnameUser { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
