using System;
using System.Collections.Generic;

namespace dict.dbases;

public partial class Student
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Patronymic { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();
}
