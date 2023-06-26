using System;
using System.Collections.Generic;

namespace dict.dbases;

public partial class Subject
{
    public int Id { get; set; }

    public string? Subname { get; set; }

    public int? TeacherId { get; set; }

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public virtual User? Teacher { get; set; }
}
