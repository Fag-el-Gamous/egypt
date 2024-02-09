using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileManipulation
{
    public string TextileManipulation1 { get; set; } = null!;

    public virtual ICollection<YarnManipulation> YarnManipulations { get; set; } = new List<YarnManipulation>();
}
