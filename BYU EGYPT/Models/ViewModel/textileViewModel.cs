namespace BYU_EGYPT.Models.ViewModel
{
    public class textileViewModel
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

        public string? TextileColor1 { get; set; } = null!;

        public string? HasPhoto { get; set; } = "No";

        public string? yarnMaterial { get; set; }

    }
}
