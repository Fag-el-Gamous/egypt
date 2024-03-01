namespace BYU_EGYPT.Models.ViewModels
{
    public class RecordsViewModel
    {
        public IQueryable<Burial>? Burials { get; set; }
        public PageInfo? PageInfo { get; set; }
    }
}
