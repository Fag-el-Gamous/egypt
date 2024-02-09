using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class BiologicalSample
{
    public int BiologicalSampleId { get; set; }

    public short? RackNumber { get; set; }

    public short? BagNumber { get; set; }

    public string? Location { get; set; }

    public short? ExcavationYear { get; set; }

    public short? BurialNumber { get; set; }

    public short? BurialSampleNumber { get; set; }

    public short? Date { get; set; }

    public string? PreviouslySampled { get; set; }

    public string? Notes { get; set; }

    public int? C14id { get; set; }

    public virtual Burial? Burial { get; set; }

    public virtual C14? C14 { get; set; }

    public virtual Location? LocationNavigation { get; set; }
}
