using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileTextileDimension
{
    public int TextileId { get; set; }

    public int DimensionId { get; set; }

    public short? BurialNumber { get; set; }

    public decimal? CentimetersLength { get; set; }

    public virtual TextileDimension Dimension { get; set; } = null!;

    public virtual Textile Textile { get; set; } = null!;
}
