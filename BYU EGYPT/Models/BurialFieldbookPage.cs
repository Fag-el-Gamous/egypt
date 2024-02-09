using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class BurialFieldbookPage
{
    public string Location { get; set; } = null!;

    public short ExcavationYear { get; set; }

    public short BurialNumber { get; set; }

    public int FieldBookId { get; set; }

    public short PdfpageNumber { get; set; }

    public virtual Burial Burial { get; set; } = null!;

    public virtual FieldBook FieldBook { get; set; } = null!;
}
