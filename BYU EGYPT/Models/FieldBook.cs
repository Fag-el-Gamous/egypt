using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class FieldBook
{
    public int FieldBookId { get; set; }

    public string? FieldBookFilePath { get; set; }

    public string? FieldBookFileName { get; set; }

    public string? YearName { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<BurialFieldbookPage> BurialFieldbookPages { get; set; } = new List<BurialFieldbookPage>();
}
