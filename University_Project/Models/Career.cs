using System;
using System.Collections.Generic;

namespace University_Project.Models;

public partial class Career
{
    public int CareerId { get; set; }

    public string CareerName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Edited { get; set; }

    public string? EditedBy { get; set; }
}
