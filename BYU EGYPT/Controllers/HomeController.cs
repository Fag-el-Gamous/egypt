﻿using System.Diagnostics;
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

    private List<Burial> Bsamples = new List<Burial>
    {
        new Burial { Location = "160 N 10 E SW", ExcavationYear = 1992, BurialNumber = "1",  HeadDirection = "U" },

    };

    // GET: Sample/Details/5
    public IActionResult BurialDetails(string BurialNumberID)
    {
        // Assumes samples is accessible here, you might need to retrieve it from the database instead
        var Bsample = Bsamples.FirstOrDefault(s => s.BurialNumber == BurialNumberID);

        if (Bsample == null)
        {
            return NotFound();
        }

        return View(Bsample);
    }

    [HttpPost]
    public async Task<IActionResult> EditRecord(Burial burial)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        egyptDbContext.Update(burial);
        egyptDbContext.SaveChanges();

        var updatedBurials = egyptDbContext.Burials.ToList();
        
        return View("BurialTable", updatedBurials);
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

    public IActionResult ArtifactTable()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var artifactList = egyptDbContext.Artifacts.ToList();
        return View(artifactList);
    }

    public IActionResult TextileTable()
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var textileList = egyptDbContext.Textiles.ToList();
        return View(textileList);
    }

    public IActionResult C14Table()
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
      //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        return View();
    }
}

