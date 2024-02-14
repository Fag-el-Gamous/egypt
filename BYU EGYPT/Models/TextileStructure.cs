using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileStructure
{
    public string TextileStructure1 { get; set; } = null!;

    public virtual ICollection<Textile> Textiles { get; set; } = new List<Textile>();
}
