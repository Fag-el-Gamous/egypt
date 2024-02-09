using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Location
{
    public string Location1 { get; set; } = null!;

    public short? MetersNorthSouth { get; set; }

    public string? NorthOrSouth { get; set; }

    public short? MetersEastWest { get; set; }

    public string? EastOrWest { get; set; }

    public string? Quadrant { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Artifact> Artifacts { get; set; } = new List<Artifact>();

    public virtual ICollection<BiologicalSample> BiologicalSamples { get; set; } = new List<BiologicalSample>();

    public virtual ICollection<Burial> Burials { get; set; } = new List<Burial>();

    public virtual ICollection<Excavation> Excavations { get; set; } = new List<Excavation>();

    public virtual ICollection<Textile> Textiles { get; set; } = new List<Textile>();
}
