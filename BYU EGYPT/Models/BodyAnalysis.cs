using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class BodyAnalysis
{
    public string Location { get; set; } = null!;

    public short ExcavationYear { get; set; }

    public string BurialNumber { get; set; } = null!;

    public string BodyAnalysisFilePath { get; set; } = null!;

    public string BodyAnalysisFileName { get; set; } = null!;

    public bool? IsCoverPhoto { get; set; }

    public virtual Burial Burial { get; set; } = null!;
}
