namespace BYU_EGYPT.Models
{
    public class ByuEgyptDbRepo
    {
        private ByuEgyptDbContext context { get; set; }
        public ByuEgyptDbRepo(ByuEgyptDbContext temp)
        {
            context = temp;
        }
        public IQueryable<Burial> Burials => context.Burials;
    }
}
