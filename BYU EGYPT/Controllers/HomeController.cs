using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BYU_EGYPT.Models;
using Microsoft.EntityFrameworkCore;

namespace BYU_EGYPT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private List<C14> samples = new List<C14>
    {
            new C14 { Rack = 5, TubeNum = 1, LocationDescription = "Hill B excavation; east side of Hill B; possibly from tomb 5", ResearchQuestions = "Hill B burials are likely Ptolemaic contrasted with the open burials which date to Roman. Are Hill B burials Ptolemaic?", AgeBp = 2175, C14sampleNum2017 = 1 },
            new C14 { Rack = 31, TubeNum = 2, LocationDescription = "Hill B excavation; west side of Hill B; possibly from tomb 1", ResearchQuestions = "Hill B burials are likely Ptolemaic contrasted with the open burials which date to Roman. Are Hill B burials Ptolemaic?", AgeBp = 2835, C14sampleNum2017 = 2 },
            
        // Add more samples as needed
    };

    // GET: Sample/Details/5
    public IActionResult Details(int sampleNum)
    {
        // Assumes samples is accessible here, you might need to retrieve it from the database instead
        var sample = samples.FirstOrDefault(s => s.C14sampleNum2017 == sampleNum);

        if (sample == null)
        {
            return NotFound();
        }

        return View(sample);
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

    public IActionResult LoadTable(string tableName)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        // Depending on the value of partialName, load the corresponding partial view
        if (tableName == "BurialTable")
        {
            var burialList = egyptDbContext.Burials.ToList();
            ViewData["BurialList"] = burialList;
            // Load and return the BurialTable partial view
            return PartialView("~/Views/Shared/PartialViews/BurialTable.cshtml");
        }
        else if (tableName == "ArtifactTable")
        {
            // Load and return the ArtifactTable partial view
            return PartialView("~/Views/Shared/PartialViews/ArtifactTable.cshtml");
        }
        else if (tableName == "C14Table")
        {
            var C14List = egyptDbContext.C14s.ToList();
            ViewData["C14List"] = C14List;
            // Load and return the ArtifactTable partial view
            return PartialView("~/Views/Shared/PartialViews/C14Table.cshtml");
        }
        else
        {
            // Return an empty result or handle the case where the partial view name is invalid
            return Content("Partial view not found.");
        }
    }

    public IActionResult Login()
    {
        return Redirect("https://cas.byu.edu/cas/login?service=https%3A%2F%2Fcas.byu.edu%2Fcas%2Fidp%2Fprofile%2FSAML2%2FCallback%3FentityId%3Dhttps%253A%252F%252Fegypt.byu.edu");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        return View();
    }
}

