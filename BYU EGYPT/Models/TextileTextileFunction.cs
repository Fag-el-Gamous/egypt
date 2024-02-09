using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileTextileFunction
{
    public int TextileId { get; set; }

    public string TextileFunction { get; set; } = null!;

    public short? BurialNumber { get; set; }

    public string? Locale { get; set; }

    public virtual Textile Textile { get; set; } = null!;

    public virtual TextileFunction TextileFunctionNavigation { get; set; } = null!;
}
