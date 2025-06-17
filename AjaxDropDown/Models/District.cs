using System;
using System.Collections.Generic;

namespace AjaxDropDown.Models;

public partial class District
{
    public int DistId { get; set; }

    public string? DisName { get; set; }

    public int? StateId { get; set; }

    public virtual State? State { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
