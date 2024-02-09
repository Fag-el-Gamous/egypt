using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileDecoration
{
    public string TextileDecoration1 { get; set; } = null!;

    public virtual ICollection<TextileTextileDecoration> TextileTextileDecorations { get; set; } = new List<TextileTextileDecoration>();
}
