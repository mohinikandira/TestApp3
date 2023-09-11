using System;
using System.Collections.Generic;

namespace TestApp3.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
