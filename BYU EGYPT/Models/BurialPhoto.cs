using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class BurialPhoto
{
    public string Location { get; set; } = null!;

    public short ExcavationYear { get; set; }

    public string BurialNumber { get; set; } = null!;

    public string BurialPhotoFilePath { get; set; } = null!;

    public string BurialPhotoFileName { get; set; } = null!;

    public bool? IsCoverPhoto { get; set; }

    public virtual Burial Burial { get; set; } = null!;
}
