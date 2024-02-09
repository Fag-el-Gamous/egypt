using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileTextileDecoration
{
    public int TextileId { get; set; }

    public short? BurialNumber { get; set; }

    public string TextileDecoration { get; set; } = null!;

    public virtual Textile Textile { get; set; } = null!;

    public virtual TextileDecoration TextileDecorationNavigation { get; set; } = null!;
}
