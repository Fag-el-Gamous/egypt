using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class FieldBook
{
    public int FieldBookId { get; set; }

    public long? BoxId { get; set; }

    public byte? YearName { get; set; }

    public string? Notes { get; set; }

    public virtual Pdf? Box { get; set; }

    public virtual ICollection<BurialFieldbookPage> BurialFieldbookPages { get; set; } = new List<BurialFieldbookPage>();
}
