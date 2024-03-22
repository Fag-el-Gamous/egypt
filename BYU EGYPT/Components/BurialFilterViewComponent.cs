using BYU_EGYPT.Data;
using BYU_EGYPT.Models;
using BYU_EGYPT.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BYU_EGYPT.Components
{
    public class BurialFilterViewComponent : ViewComponent
    {
        private readonly ByuEgyptDbContext egyptDbContext;
        public BurialFilterViewComponent(ByuEgyptDbContext context)
        {
            egyptDbContext = context;
        }

        public IViewComponentResult Invoke()
        {
            var burials = egyptDbContext.Burials
                .Select(x => new burialViewModel
                {
                    BurialNumber = x.BurialNumber,
                    Location = x.Location,
                    ExcavationYear = x.ExcavationYear,
                    Depth = x.Depth,
                    AgeGroup = x.AgeGroup,
                    Sex = x.Sex
                })
                .Distinct()
                .OrderBy(x => Convert.ToInt32(x.BurialNumber));

            return View(burials);
        }
    }
}
