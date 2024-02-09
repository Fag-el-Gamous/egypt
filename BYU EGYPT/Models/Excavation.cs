using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Excavation
{
    public string Location { get; set; } = null!;

    public short Year { get; set; }

    public string SourceInformation { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Location LocationNavigation { get; set; } = null!;
}
