﻿using Microsoft.AspNetCore.Mvc;
using BYU_EGYPT.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BYU_EGYPT.Models.ViewModel;
using BYU_EGYPT.Data;

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

    // Burial Table
    public IActionResult BurialTable(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var textiles = egyptDbContext.Textiles;
        var artifacts = egyptDbContext.Artifacts;

        IEnumerable<burialViewModel> joinedData = null;

        joinedData = (from b in egyptDbContext.Burials
                      join t in textiles
                      on new { b.Location, b.ExcavationYear, b.BurialNumber }
                      equals new { Location = (string?)t.Location, ExcavationYear = (short)t.ExcavationYear, BurialNumber = (string?)t.BurialNumber }
                      into textileGroup
                      from t in textileGroup.DefaultIfEmpty()
                      join a in artifacts
                      on new { b.Location, b.ExcavationYear, b.BurialNumber }
                      equals new { a.Location, ExcavationYear = (short)a.ExcavationYear, a.BurialNumber }
                      into artifactGroup
                      from a in artifactGroup.DefaultIfEmpty()
                      select new burialViewModel
                      {
                          TextileId = t.TextileId,
                          BurialNumber = b.BurialNumber,
                          ExcavationYear = b.ExcavationYear,
                          Location = b.Location,
                          TextileReferenceNumber = t.TextileReferenceNumber,
                          AnalysisType = t.AnalysisType,
                          AnalysisDate = t.AnalysisDate,
                          SampleTakenDate = t.SampleTakenDate,
                          Description = t.Description,
                          AnalysisBy = t.AnalysisBy,
                          Depth = b.Depth,
                          AgeGroup = b.AgeGroup,
                          Sex = b.Sex,
                          HairColor = b.HairColor,
                          HeadDirection = b.HeadDirection,
                          HasTextileInfo = t != null ? "Yes" : "No",
                          HasArtifactInfo = a != null ? "Yes" : "No",
                          HasArtifactPhoto = a.HasPhotos != null ? "Yes" : "No",
                          yarnMaterial = null,
                          HasBodyAnalysisInfo = b.BodyExaminationDate != null ? "Yes" : "No"
                      }
                 ).OrderBy(b => b.Location)
                 .ThenBy(b => Convert.ToInt32(b.BurialNumber))
                 .Skip((pageNum - 1) * pageSize)
                 .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(joinedData);
    }

    // Related Burials Table
    public IActionResult RelatedBurials(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var textiles = egyptDbContext.Textiles;
        var artifacts = egyptDbContext.Artifacts;

        IEnumerable<burialViewModel> joinedData = null;

        joinedData = (from b in egyptDbContext.Burials
                      join t in textiles
                      on new { b.Location, b.ExcavationYear, b.BurialNumber }
                      equals new { Location = (string?)t.Location, ExcavationYear = (short)t.ExcavationYear, BurialNumber = (string?)t.BurialNumber }
                      into textileGroup
                      from t in textileGroup.DefaultIfEmpty()
                      join a in artifacts
                      on new { b.Location, b.ExcavationYear, b.BurialNumber }
                      equals new { a.Location, ExcavationYear = (short)a.ExcavationYear, a.BurialNumber }
                      into artifactGroup
                      from a in artifactGroup.DefaultIfEmpty()
                      select new burialViewModel
                      {
                          TextileId = t.TextileId,
                          BurialNumber = b.BurialNumber,
                          ExcavationYear = b.ExcavationYear,
                          Location = b.Location,
                          TextileReferenceNumber = t.TextileReferenceNumber,
                          AnalysisType = t.AnalysisType,
                          AnalysisDate = t.AnalysisDate,
                          SampleTakenDate = t.SampleTakenDate,
                          Description = t.Description,
                          AnalysisBy = t.AnalysisBy,
                          Depth = b.Depth,
                          AgeGroup = b.AgeGroup,
                          Sex = b.Sex,
                          HairColor = b.HairColor,
                          HeadDirection = b.HeadDirection,
                          HasTextileInfo = t != null ? "Yes" : "No",
                          HasArtifactInfo = a != null ? "Yes" : "No",
                          HasArtifactPhoto = a.HasPhotos != null ? "Yes" : "No",
                          yarnMaterial = null,
                          HasBodyAnalysisInfo = b.BodyExaminationDate != null ? "Yes" : "No"
                      }
                 ).OrderBy(b => b.Location)
                 .ThenBy(b => Convert.ToInt32(b.BurialNumber))
                 .Skip((pageNum - 1) * pageSize)
                 .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(joinedData);
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

    // Related Artifacts Table
    public IActionResult RelatedArtifacts(int pageNum = 1)
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
                              yarnMaterial = ym.Material
                          }
            ).OrderBy(b => b.TextileId)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.CurrentPage = pageNum;

        return View(joinedTextiles);
    }

    // Related Textiles Table
    public IActionResult RelatedTextiles(int pageNum = 1)
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
                              yarnMaterial = ym.Material
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
            //.ThenBy(b => b.BurialNumber) c14 has no burial number column
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(c14list);
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
            .OrderBy(b => b.Location)
            .ThenBy(b => Convert.ToInt32(b.BurialNumber))
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(osteologylist);
    }

    // Related Osteology Table
    public IActionResult RelatedOsteology(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        int pageSize = 12;

        var osteologylist = egyptDbContext.Burials
            .OrderBy(b => b.Location)
            .ThenBy(b => Convert.ToInt32(b.BurialNumber))
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
        .OrderBy(b => b.Location)
        .ThenBy(b => b.BurialNumber) //Cannot convert Cranium burialnumber to int because it has letters in its values (ex. 2A)
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
