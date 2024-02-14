using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class BurialPhoto
{
    public long BoxId { get; set; }

    public string Location { get; set; } = null!;

    public short ExcavationYear { get; set; }

    public string BurialNumber { get; set; } = null!;

    public bool? IsCoverPhoto { get; set; }

    public virtual Photo Box { get; set; } = null!;

    public virtual Burial Burial { get; set; } = null!;
}
