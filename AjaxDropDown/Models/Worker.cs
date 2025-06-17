
namespace AjaxDropDown.Models;

public partial class Worker
{
    public int WorkId { get; set; }

    public string? WorkName { get; set; }

    public DateOnly? WorkDob { get; set; }

    public int? StateId { get; set; }

    public int? DistId { get; set; }

    public virtual District? Dist { get; set; }

    public virtual State? State { get; set; }
}
