using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class CraniumPhoto
{
    public int CraniaId { get; set; }

    public long BoxId { get; set; }

    public bool? IsCoverPhoto { get; set; }

    public virtual Photo Box { get; set; } = null!;

    public virtual Cranium Crania { get; set; } = null!;
}
