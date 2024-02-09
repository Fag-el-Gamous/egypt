using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextilePhoto
{
    public long BoxId { get; set; }

    public int TextileId { get; set; }

    public bool? IsCoverPhoto { get; set; }

    public virtual Photo Box { get; set; } = null!;

    public virtual Textile Textile { get; set; } = null!;
}
