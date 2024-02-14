using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class PersonTextile
{
    public int PersonId { get; set; }

    public int TextileId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Textile Textile { get; set; } = null!;
}
