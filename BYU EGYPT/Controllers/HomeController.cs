using Microsoft.AspNetCore.Mvc;
using BYU_EGYPT.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BYU_EGYPT.Models.ViewModel;

namespace BYU_EGYPT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ByuEgyptDbContext _context;

    public HomeController(ILogger<HomeController> logger, ByuEgyptDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Research()
    {
        return View();
    }

    public IActionResult Data()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();

        return View();
    }

    // ------------------------------- TABLES -------------------------------

 

    // Burial Data
    public IActionResult BurialTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var burials = egyptDbContext.Burials
            .OrderBy(b => b.BurialNumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(burials);
    }


    // Burial Details Page
    public IActionResult BurialDetails(string BurialNumberID, string Location, string ExcavationYear)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();


        var burialsample = _context.Burials.FirstOrDefault(x => x.BurialNumber == BurialNumberID);
        if (burialsample == null)
        {
            return NotFound();
        }

        return View("BurialDetails", burialsample); // Assuming C14Details view exists

    }


    // Artifact Table
    public IActionResult ArtifactTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var artifacts = egyptDbContext.Artifacts
            .OrderBy(b => b.ArtifactId)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(artifacts);
    }

    // Artifact Table Data
    public IActionResult ArtifactTableData()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var artifactList = egyptDbContext.Artifacts.ToList();
        return View(artifactList);
    }

    // Artifact Details Page
    public IActionResult ArtifactDetails(string ArtifactID)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();


        var artifactsample = _context.Artifacts.FirstOrDefault(x => x.ArtifactId == ArtifactID);
        if (artifactsample == null)
        {
            return NotFound();
        }

        return View("ArtifactDetails", artifactsample); // Assuming C14Details view exists
    }

    // Textile Table
    public IActionResult TextileTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var textileColors = egyptDbContext.TextileColors;
        var textilePhoto = egyptDbContext.TextilePhotos;
        var yarnManipulation = egyptDbContext.YarnManipulations;
        IEnumerable<textileViewModel> joinedTextiles = null;

        joinedTextiles = (from t in egyptDbContext.Textiles
                 join tp in textilePhoto on t.TextileId equals tp.TextileId into tpGroup
                 from tp in tpGroup.DefaultIfEmpty()
                 join ym in yarnManipulation on t.TextileId equals ym.TextileId into ymGroup
                 from ym in ymGroup.DefaultIfEmpty()
                 select new textileViewModel
                 {
                     TextileId = t.TextileId,
                     BurialNumber = t.BurialNumber,
                     ExcavationYear = t.ExcavationYear,
                     Location = t.Location,
                     TextileReferenceNumber = t.TextileReferenceNumber,
                     AnalysisType = t.AnalysisType,
                     AnalysisDate = t.AnalysisDate,
                     SampleTakenDate = t.SampleTakenDate,
                     Description = t.Description,
                     AnalysisBy = t.AnalysisBy,
                     HasPhoto = tp != null ? "Yes" : "No",
                     yarnMaterial = ym != null ? ym.Material : null
                 }
            ).OrderBy(b => b.TextileId)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.CurrentPage = pageNum;

        return View(joinedTextiles);
    }

    // Textile Details Page
    public IActionResult TextileDetails(int TextileID)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();


        var textilesample = _context.Textiles.FirstOrDefault(x => x.TextileId == TextileID);
        if (textilesample == null)
        {
            return NotFound();
        }

        return View("TextileDetails", textilesample); // Assuming C14Details view exists

    }

    // C14 Table
    public IActionResult C14Table(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var c14list = egyptDbContext.C14s
            .OrderBy(b => b.C14id)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(c14list);
    }

    // C14 Table Data
    public IActionResult C14TableData()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var c14List = egyptDbContext.C14s.ToList();
        return View(c14List);
    }

    // C14 Details Page
    public IActionResult C14Details(string BurialNumberID, string Location, string ExcavationYear)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();

        var burialsample = _context.Burials.FirstOrDefault(x => x.BurialNumber == BurialNumberID);
        if (burialsample == null)
        {
            return NotFound();
        }

        return View("BurialDetails", burialsample);
    }

    // Osteology Table
    public IActionResult OsteologyTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var osteologylist = egyptDbContext.Burials
            .OrderBy(b => b.BurialNumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(osteologylist);
    }

    // Osteology Details Page
    public IActionResult OsteologyDetails(string BurialNumberID, string Location, string ExcavationYear)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();

        var burialsample = _context.Burials.FirstOrDefault(x => x.BurialNumber == BurialNumberID);
        if (burialsample == null)
        {
            return NotFound();
        }

        return View("BurialDetails", burialsample);
    }

    // Crania Table
    public IActionResult CraniaTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var cranialist = egyptDbContext.Crania
        .OrderBy(b => b.CraniaId)
        .Skip((pageNum - 1) * pageSize)
        .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(cranialist);
    }

    // Crania Details Page
    public IActionResult CraniaDetails(string BurialNumberID, string Location, string ExcavationYear)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();

        var burialsample = _context.Burials.FirstOrDefault(x => x.BurialNumber == BurialNumberID);
        if (burialsample == null)
        {
            return NotFound();
        }

        return View("BurialDetails", burialsample);
    }

    // ------------------------------- END OF TABLES -------------------------------
    // Edit Record
    [HttpPost]
    public async Task<IActionResult> EditRecord(Burial burial)
    {

        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        egyptDbContext.Update(burial);
        await egyptDbContext.SaveChangesAsync(); // Use async version of SaveChanges

        return RedirectToAction("BurialTableData"); // Redirect to the BurialTableData action
    }

    public IActionResult Login()
    {
        return Redirect("https://cas.byu.edu/cas/login?service=https%3A%2F%2Fcas.byu.edu%2Fcas%2Fidp%2Fprofile%2FSAML2%2FCallback%3FentityId%3Dhttps%253A%252F%252Fegypt.byu.edu");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {

        return View();
    }
}
