using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Artifact
{
    public string ArtifactId { get; set; } = null!;

    public string? Location { get; set; }

    public string? Position { get; set; }

    public short? MetersNorthSouth { get; set; }

    public string? NorthOrSouth { get; set; }

    public short? MetersEastWest { get; set; }

    public string? EastOrWest { get; set; }

    public short? BurialNumber { get; set; }

    public short? ExcavationYear { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Material { get; set; }

    public string? Condition { get; set; }

    public string? Dimensions { get; set; }

    public string? Notes { get; set; }

    public string? ArtifactEra { get; set; }

    public string? Provenance { get; set; }

    public bool? IsSurfaceFind { get; set; }

    public byte? FindDay { get; set; }

    public byte? FindMonth { get; set; }

    public short? FindYear { get; set; }

    public DateTime? FindDate { get; set; }

    public string? Finder { get; set; }

    public string? ExcavatorNum { get; set; }

    public DateTime? KomAushimEntryDate { get; set; }

    public string? StorageSite { get; set; }

    public string? LocationAtSite { get; set; }

    public string? ConservationNotes { get; set; }

    public bool? HasPhotos { get; set; }

    public string? Colors { get; set; }

    public int? PersonId { get; set; }

    public virtual ICollection<ArtifactPhoto> ArtifactPhotos { get; set; } = new List<ArtifactPhoto>();

    public virtual Burial? Burial { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual Person? Person { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
