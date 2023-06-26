using System;
using System.Collections.Generic;

namespace dict.dbases;

public partial class Mark
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? MarkId { get; set; }

    public int? SubId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Marktype? MarkNavigation { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Sub { get; set; }
}
