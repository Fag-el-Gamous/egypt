using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileDimension
{
    public int DimensionId { get; set; }

    public string DimensionType { get; set; } = null!;

    public virtual ICollection<TextileTextileDimension> TextileTextileDimensions { get; set; } = new List<TextileTextileDimension>();
}
