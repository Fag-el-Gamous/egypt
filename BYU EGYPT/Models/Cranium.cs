using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Cranium
{
    public int CraniaId { get; set; }

    public string? Location { get; set; }

    public short? ExcavationYear { get; set; }

    public short? BurialNumber { get; set; }

    public decimal? MaxCraniaLength { get; set; }

    public decimal? MaxCraniaBreadth { get; set; }

    public decimal? BasionBregmaHeight { get; set; }

    public decimal? BasionNasionLength { get; set; }

    public decimal? BasionProsthionLength { get; set; }

    public decimal? BizygomaticDiameter { get; set; }

    public decimal? NasionProsthionHeight { get; set; }

    public decimal? MaxNasalBreadth { get; set; }

    public decimal? InterorbitalBreadth { get; set; }

    public string? Sex { get; set; }

    public string? CalculatedSex { get; set; }

    public bool? SexMatch { get; set; }

    public decimal? CalcMaxCraniaLength { get; set; }

    public decimal? CalcBasionNasion { get; set; }

    public decimal? CalcBasionProsthion { get; set; }

    public decimal? CalcBizygomaticDiameter { get; set; }

    public decimal? CalcNasionProsthionHeight { get; set; }

    public decimal? CraniaCalcSum { get; set; }

    public virtual Burial? Burial { get; set; }

    public virtual ICollection<CraniumPhoto> CraniumPhotos { get; set; } = new List<CraniumPhoto>();
}
