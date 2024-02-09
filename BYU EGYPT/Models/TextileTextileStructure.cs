using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileTextileStructure
{
    public int TextileId { get; set; }

    public short? BurialNumber { get; set; }

    public string TextileStructure { get; set; } = null!;

    public virtual Textile Textile { get; set; } = null!;

    public virtual TextileStructure TextileStructureNavigation { get; set; } = null!;
}
