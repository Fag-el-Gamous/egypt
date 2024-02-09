using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Photo
{
    public long BoxId { get; set; }

    public string? FileName { get; set; }

    public virtual ICollection<ArtifactPhoto> ArtifactPhotos { get; set; } = new List<ArtifactPhoto>();

    public virtual ICollection<BurialPhoto> BurialPhotos { get; set; } = new List<BurialPhoto>();

    public virtual ICollection<CraniumPhoto> CraniumPhotos { get; set; } = new List<CraniumPhoto>();

    public virtual ICollection<TextilePhoto> TextilePhotos { get; set; } = new List<TextilePhoto>();
}
