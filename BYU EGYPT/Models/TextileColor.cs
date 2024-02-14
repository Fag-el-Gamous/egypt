using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileColor
{
    public string TextileColor1 { get; set; } = null!;

    public virtual ICollection<Textile> Textiles { get; set; } = new List<Textile>();
}
