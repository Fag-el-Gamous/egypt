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
        var c14List = egyptDbContext.C14s.ToList();

        return View(c14List);
    }

    public IActionResult Login()
    {
        return Redirect("https://cas.byu.edu/cas/login?service=https%3A%2F%2Fcas.byu.edu%2Fcas%2Fidp%2Fprofile%2FSAML2%2FCallback%3FentityId%3Dhttps%253A%252F%252Fegypt.byu.edu");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

