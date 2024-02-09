using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileTextileColor
{
    public int TextileId { get; set; }

    public short? BurialNumber { get; set; }

    public string TextileColor { get; set; } = null!;

    public virtual Textile Textile { get; set; } = null!;

    public virtual TextileColor TextileColorNavigation { get; set; } = null!;
}
