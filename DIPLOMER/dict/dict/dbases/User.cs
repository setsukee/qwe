using System;
using System.Collections.Generic;

namespace dict.dbases;

public partial class User
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Patronymic { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
