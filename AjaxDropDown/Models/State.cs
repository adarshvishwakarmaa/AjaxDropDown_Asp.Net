using System;
using System.Collections.Generic;

namespace AjaxDropDown.Models;

public partial class State
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
