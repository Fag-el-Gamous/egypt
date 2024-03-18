using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class CraniumAnalysisSheet
{
    public int CraniumId { get; set; }

    public string CraniumAnalysisSheetFilePath { get; set; } = null!;

    public string CraniumAnalysisSheetFileName { get; set; } = null!;
}
