using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class ArtifactPhoto
{
    public string ArtifactId { get; set; } = null!;

    public long BoxId { get; set; }

    public bool? IsCoverPhoto { get; set; }

    public virtual Artifact Artifact { get; set; } = null!;

    public virtual Photo Box { get; set; } = null!;
}
