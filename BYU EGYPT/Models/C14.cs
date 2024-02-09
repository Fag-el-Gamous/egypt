using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class C14
{
    public int C14id { get; set; }

    public string? Contents { get; set; }

    public string? LocationDescription { get; set; }

    public int? Rack { get; set; }

    public int? TubeNum { get; set; }

    public double? Sizeml { get; set; }

    public int? NumFoci { get; set; }

    public int? C14sampleNum2017 { get; set; }

    public double? AgeBp { get; set; }

    public int? CalendarDate { get; set; }

    public double? CalendarDateMax95 { get; set; }

    public double? CalendarDateMin95 { get; set; }

    public string? ResearchQuestions { get; set; }

    public int? ResearchQuestionsNum { get; set; }

    public string? Labs { get; set; }

    public string? Notes { get; set; }

    public string? Other { get; set; }

    public virtual ICollection<BiologicalSample> BiologicalSamples { get; set; } = new List<BiologicalSample>();
}
