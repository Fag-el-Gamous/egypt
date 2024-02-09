using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Burial
{
    public string Location { get; set; } = null!;

    public short ExcavationYear { get; set; }

    public short BurialNumber { get; set; }

    public string? HillDesignation { get; set; }

    public short? TombNumber { get; set; }

    public string? HeadDirection { get; set; }

    public decimal? WestToHead { get; set; }

    public decimal? WestToFeet { get; set; }

    public decimal? SouthToHead { get; set; }

    public decimal? SouthToFeet { get; set; }

    public decimal? Depth { get; set; }

    public decimal? Length { get; set; }

    public byte? ExcavationDay { get; set; }

    public byte? ExcavationMonth { get; set; }

    public string? BodyPreservationLevel { get; set; }

    public string? WrappingLevel { get; set; }

    public string? AdultSubadult { get; set; }

    public string? AgeGroup { get; set; }

    public string? EstimatedAgeAtDeath { get; set; }

    public string? Sex { get; set; }

    public string? HairColor { get; set; }

    public string? HairDescription { get; set; }

    public bool? HasSamples { get; set; }

    public bool? HasFaceBundle { get; set; }

    public bool? HasGraveGoods { get; set; }

    public string? GraveGoodsDescription { get; set; }

    public bool? HasPhotos { get; set; }

    public string? BurialNotes { get; set; }

    public DateTime? BodyExaminationDate { get; set; }

    public byte? BodyPreservationIndex { get; set; }

    public string? RobustCrania { get; set; }

    public string? SupraorbitalRidgesCrania { get; set; }

    public string? OrbitEdgeCrania { get; set; }

    public string? ParietalBossingCrania { get; set; }

    public string? GonionCrania { get; set; }

    public string? NuchalCrestCrania { get; set; }

    public string? ZygomaticCrestCrania { get; set; }

    public string? SphenoOccipitalSynchondrosisCrania { get; set; }

    public string? LamboidSutureCrania { get; set; }

    public string? SquamousSutureCrania { get; set; }

    public string? ToothAttrition { get; set; }

    public string? ToothEruptionDescription { get; set; }

    public string? ToothEruptionAgeEstimate { get; set; }

    public string? VentralArcPelvis { get; set; }

    public string? SubpubicAnglePelvis { get; set; }

    public string? SciaticNotchPelvis { get; set; }

    public string? PubicBonePelvis { get; set; }

    public bool? PreauricularSulcusPelvis { get; set; }

    public string? MedialIpramusPelvis { get; set; }

    public string? DorsalPittingPelvis { get; set; }

    public string? FemurEpiphysealUnion { get; set; }

    public string? HumerusEpiphysealUnion { get; set; }

    public decimal? FemurHeadDiameter { get; set; }

    public decimal? HumerusHeadDiameter { get; set; }

    public decimal? FemurLength { get; set; }

    public decimal? HumerusLength { get; set; }

    public decimal? TibiaLength { get; set; }

    public decimal? EstimateStature { get; set; }

    public string? EstimateSex { get; set; }

    public string? Osteophytosis { get; set; }

    public string? CariesPeriodontalDisease { get; set; }

    public string? BodyAnalysisNotes { get; set; }

    public virtual ICollection<Artifact> Artifacts { get; set; } = new List<Artifact>();

    public virtual ICollection<BiologicalSample> BiologicalSamples { get; set; } = new List<BiologicalSample>();

    public virtual ICollection<BurialFieldbookPage> BurialFieldbookPages { get; set; } = new List<BurialFieldbookPage>();

    public virtual ICollection<BurialPhoto> BurialPhotos { get; set; } = new List<BurialPhoto>();

    public virtual ICollection<Cranium> Crania { get; set; } = new List<Cranium>();

    public virtual Location LocationNavigation { get; set; } = null!;

    public virtual ICollection<Textile> Textiles { get; set; } = new List<Textile>();

    public virtual ICollection<Pdf> Boxes { get; set; } = new List<Pdf>();
}
