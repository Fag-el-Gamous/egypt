using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class BiologicalSample
{
    public int BiologicalSampleId { get; set; }

    public short? RackNumber { get; set; }

    public short? BagNumber { get; set; }

    public short? TubeNumber { get; set; }

    public double? SizeMl { get; set; }

    public string? Location { get; set; }

    public string? BurialNumber { get; set; }

    public short? ExcavationYear { get; set; }

    public string? Contents { get; set; }

    public string? StorageNotes { get; set; }

    public string? Initials { get; set; }

    public virtual Burial? Burial { get; set; }

    public virtual ICollection<C14> C14s { get; set; } = new List<C14>();

    public virtual Location? LocationNavigation { get; set; }
}
