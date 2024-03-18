using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class CraniumPhoto
{
    public int CraniumId { get; set; }

    public string CraniumPhotoFilePath { get; set; } = null!;

    public string CraniumPhotoFileName { get; set; } = null!;

    public bool? IsCoverPhoto { get; set; }

    public virtual Cranium Cranium { get; set; } = null!;
}
