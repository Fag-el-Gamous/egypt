using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class BodyAnalysisSheet
{
    public string Location { get; set; } = null!;

    public short ExcavationYear { get; set; }

    public string BurialNumber { get; set; } = null!;

    public string BodyAnalysisSheetFilePath { get; set; } = null!;

    public string BodyAnalysisSheetFileName { get; set; } = null!;

    public virtual Burial Burial { get; set; } = null!;
}
