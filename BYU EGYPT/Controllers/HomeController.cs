using Microsoft.AspNetCore.Mvc;
using BYU_EGYPT.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
    
    //private List<Burial> Bsamples = new List<Burial>
    //{
    //    new Burial { Location = "160 N 10 E SW", ExcavationYear = 1992, BurialNumber = "1",  HeadDirection = "U" },




    //    // Add more samples as needed
    //};

    //// GET: Sample/Details/5
    //public IActionResult BurialDetails(string BurialNumberID)
    //{
    //    // Assumes samples is accessible here, you might need to retrieve it from the database instead
    //    var Bsample = Bsamples.FirstOrDefault(s => s.BurialNumber == BurialNumberID);

    //    if (Bsample == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(Bsample);
    //}

    public IActionResult C14Table()
    {
        var list = _context.C14s.ToList();
        ViewData["C14List"] = list;
        return View();
    }

    public IActionResult C14Details(int? c14sampleNum2017)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();
        if (!c14sampleNum2017.HasValue)
        {
            return NotFound();
        }

        var c14sample = _context.C14s.FirstOrDefault(x => x.C14sampleNum2017 == c14sampleNum2017.Value);
        if (c14sample == null)
        {
            return NotFound();
        }

        return View("C14Details", c14sample); // Assuming C14Details view exists
    }

    public IActionResult C14TableData()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var c14List = egyptDbContext.C14s.ToList();
        return View(c14List);
    }

    public IActionResult BurialTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 20;

        var burials = egyptDbContext.Burials
            .OrderBy(b => b.BurialNumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);
            //.ToList();
    //var burialList = egyptDbContext.Burials.ToList();
        return View(burials);
    }

    public IActionResult BurialDetails(string BurialNumberID)

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

    //public IActionResult BurialTableData()
    //{
    //    ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
    //    var burialList = egyptDbContext.Burials.ToList();
    //    return View(burialList);
    //}

    public IActionResult BurialTableData(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 10;

        var burials = egyptDbContext.Burials
            .OrderBy(b => b.BurialNumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);
        //.ToList();
        //var burialList = egyptDbContext.Burials.ToList();
        return View(burials);
    }
    //[HttpPost]
    //public async Task<IActionResult> EditRecord(Burial burial)
    //{
    //    ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
    //    egyptDbContext.Update(burial);
    //    egyptDbContext.SaveChanges();

    //    var updatedBurials = egyptDbContext.Burials.ToList();

    //    return View("BurialTable", updatedBurials);
    //}
    [HttpPost]
    public async Task<IActionResult> EditRecord(Burial burial)
    {

        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        egyptDbContext.Update(burial);
        await egyptDbContext.SaveChangesAsync(); // Use async version of SaveChanges

        return RedirectToAction("BurialTableData"); // Redirect to the BurialTableData action
    }

    public IActionResult ArtifactTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 10;

        var artifacts = egyptDbContext.Artifacts
            .OrderBy(b => b.ArtifactId)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);
        return View(artifacts);
    }

    public IActionResult ArtifactTableData()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var artifactList = egyptDbContext.Artifacts.ToList();
        return View(artifactList);
    }









    public IActionResult TextileTable()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();
        return View();
    }



    public IActionResult TextileTableData()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();
        return View(textileList);
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

