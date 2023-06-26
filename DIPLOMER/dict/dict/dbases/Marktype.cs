using System;
using System.Collections.Generic;

namespace dict.dbases;

public partial class Marktype
{
    public int Id { get; set; }

    public int? Mark { get; set; }

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();
}
