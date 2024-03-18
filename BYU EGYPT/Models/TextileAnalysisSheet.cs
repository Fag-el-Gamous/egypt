using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class TextileAnalysisSheet
{
    public int TextileId { get; set; }

    public string TextileAnalysisSheetFilePath { get; set; } = null!;

    public string TextileAnalysisSheetFileName { get; set; } = null!;

    public virtual Textile Textile { get; set; } = null!;
}
