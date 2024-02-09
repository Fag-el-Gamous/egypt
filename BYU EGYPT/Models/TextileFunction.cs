using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileFunction
{
    public string TextileFunction1 { get; set; } = null!;

    public string? TextileFunctionNotes { get; set; }

    public virtual ICollection<TextileTextileFunction> TextileTextileFunctions { get; set; } = new List<TextileTextileFunction>();
}
