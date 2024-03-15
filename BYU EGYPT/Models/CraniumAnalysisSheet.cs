using System.ComponentModel.DataAnnotations;

namespace BYU_EGYPT.Models
{
    public class CraniumAnalysisSheet
    {
        public int CraniumID { get; set; }
        [Required]
        [Key]
        public string CraniumAnalysisSheetFilePath { get; set; }
        [Required]
        public string CraniumAnalysisSheetFileName { get; set; }
    }
}
