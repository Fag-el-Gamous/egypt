using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Textile
{
    public int TextileId { get; set; }

    public string? BurialNumber { get; set; }

    public short? ExcavationYear { get; set; }

    public string? Location { get; set; }

    public string? TextileReferenceNumber { get; set; }

    public string? AnalysisType { get; set; }

    public DateTime? AnalysisDate { get; set; }

    public DateTime? SampleTakenDate { get; set; }

    public string? Description { get; set; }

    public string? AnalysisBy { get; set; }

    public virtual Burial? Burial { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<TextilePhoto> TextilePhotos { get; set; } = new List<TextilePhoto>();

    public virtual ICollection<TextileTextileDimension> TextileTextileDimensions { get; set; } = new List<TextileTextileDimension>();

    public virtual ICollection<TextileTextileFunction> TextileTextileFunctions { get; set; } = new List<TextileTextileFunction>();

    public virtual ICollection<YarnManipulation> YarnManipulations { get; set; } = new List<YarnManipulation>();

    public virtual ICollection<Pdf> Boxes { get; set; } = new List<Pdf>();

    public virtual ICollection<TextileColor> TextileColors { get; set; } = new List<TextileColor>();

    public virtual ICollection<TextileDecoration> TextileDecorations { get; set; } = new List<TextileDecoration>();

    public virtual ICollection<TextileStructure> TextileStructures { get; set; } = new List<TextileStructure>();
}
