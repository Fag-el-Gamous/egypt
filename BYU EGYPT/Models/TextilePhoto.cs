using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextilePhoto
{
    public int TextileId { get; set; }

    public string TextilePhotoFilePath { get; set; } = null!;

    public string TextilePhotoFileName { get; set; } = null!;

    public bool? IsCoverPhoto { get; set; }

    public virtual Textile Textile { get; set; } = null!;
}
