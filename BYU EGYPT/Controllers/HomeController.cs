using Microsoft.AspNetCore.Mvc;
using BYU_EGYPT.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BYU_EGYPT.Models.ViewModel;
using BYU_EGYPT.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

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


        var burialsample = _context.Burials
            .Include(b => b.BurialPhotos)
            .FirstOrDefault(x => x.BurialNumber == BurialNumberID);
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

    // Related C14 Table
    public IActionResult RelatedC14(int pageNum = 1)
    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var burial = egyptDbContext.Burials;
        var biologicalSample = egyptDbContext.BiologicalSamples;
        int pageSize = 12;

        IEnumerable<c14ViewModel> joinedC14 = null;

        joinedC14 = (from c14 in egyptDbContext.C14s
                        join bs in biologicalSample on c14.BiologicalSampleId equals bs.BiologicalSampleId into cbGroup
                        from bs in cbGroup.DefaultIfEmpty()
                        join b in burial on bs.BurialNumber equals b.BurialNumber into bbGroup
                        from b in bbGroup.DefaultIfEmpty()
                     select new c14ViewModel
                     {
                         BiologicalSampleId = c14.BiologicalSampleId,
                         Contents = c14.Contents,
                         LocationDescription = c14.LocationDescription,
                         Rack = c14.Rack,
                         TubeNum = c14.TubeNum,
                         Sizeml = c14.Sizeml,
                         NumFoci = c14.NumFoci,
                         C14sampleNum2017 = c14.C14sampleNum2017,
                         AgeBp = c14.AgeBp,
                         CalendarDate = c14.CalendarDate,
                         CalendarDateMax95 = c14.CalendarDateMax95,
                         CalendarDateMin95 = c14.CalendarDateMin95,
                         ResearchQuestions = c14.ResearchQuestions,
                         ResearchQuestionsNum = c14.ResearchQuestionsNum,
                         Labs = c14.Labs
                     }
            ).OrderBy(x => x.BiologicalSampleId)
            //.ThenBy(x => x.BurialNumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.CurrentPage = pageNum;

        return View(joinedC14);
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

        var textiles = egyptDbContext.Textiles;
        var artifacts = egyptDbContext.Artifacts;

        IEnumerable<burialViewModel> joinedData = null;

        joinedData = (from b in egyptDbContext.Burials
                      //join t in textiles
                      //on new { b.Location, b.ExcavationYear, b.BurialNumber }
                      //equals new { Location = (string?)t.Location, ExcavationYear = (short)t.ExcavationYear, BurialNumber = (string?)t.BurialNumber }
                      //into textileGroup
                      //from t in textileGroup.DefaultIfEmpty()
                      //join a in artifacts
                      //on new { b.Location, b.ExcavationYear, b.BurialNumber }
                      //equals new { a.Location, ExcavationYear = (short)a.ExcavationYear, a.BurialNumber }
                      //into artifactGroup
                      //from a in artifactGroup.DefaultIfEmpty()
                      select new burialViewModel
                      {
                          BurialNumber = b.BurialNumber, //NEEDED?
                          ExcavationYear = b.ExcavationYear, //NEEDED?
                          Location = b.Location, //NEEDED?
                          BodyExaminationDate = b.BodyExaminationDate,
                          BodyPreservationIndex = b.BodyPreservationIndex,
                          RobustCrania = b.RobustCranium,
                          SupraorbitalRidgesCrania = b.SupraorbitalRidgesCranium,
                          OrbitEdgeCrania = b.OrbitEdgeCranium,
                          ParietalBossingCrania = b.ParietalBossingCranium,
                          GonionCrania = b.GonionCranium,
                          NuchalCrestCrania = b.NuchalCrestCranium,
                          ZygomaticCrestCrania = b.ZygomaticCrestCranium,
                          SphenoOccipitalSynchondrosisCrania = b.SphenoOccipitalSynchondrosisCranium,
                          LamboidSutureCrania = b.LamboidSutureCranium,
                          SquamousSutureCrania = b.SquamousSutureCranium,
                          ToothAttrition = b.ToothAttrition,
                          ToothEruptionDescription = b.ToothEruptionDescription,
                          ToothEruptionAgeEstimate = b.ToothEruptionAgeEstimate,
                          VentralArcPelvis = b.VentralArcPelvis,
                          SubpubicAnglePelvis = b.SubpubicAnglePelvis,
                          SciaticNotchPelvis = b.SciaticNotchPelvis,
                          PubicBonePelvis = b.PubicBonePelvis,
                          PreauricularSulcusPelvis = b.PreauricularSulcusPelvis,
                          MedialIpramusPelvis = b.MedialIpramusPelvis,
                          DorsalPittingPelvis = b.DorsalPittingPelvis,
                          FemurEpiphysealUnion = b.FemurEpiphysealUnion,
                          HumerusEpiphysealUnion = b.HumerusEpiphysealUnion,
                          FemurHeadDiameter = b.FemurHeadDiameter,
                          HumerusHeadDiameter = b.HumerusHeadDiameter,
                          FemurLength = b.FemurLength,
                          HumerusLength = b.HumerusLength,
                          TibiaLength = b.TibiaLength,
                          EstimateStature = b.EstimateStature,
                          EstimateSex = b.EstimateSex,
                          Osteophytosis = b.Osteophytosis,
                          CariesPeriodontalDisease = b.CariesPeriodontalDisease,
                          BodyAnalysisNotes = b.BodyAnalysisNotes
                          //CLUSTER NUMBER?
                          //SHAFT NUMBER?
                      }
                 ).OrderBy(b => b.Location)
                 .ThenBy(b => Convert.ToInt32(b.BurialNumber))
                 .Skip((pageNum - 1) * pageSize)
                 .Take(pageSize);

        ViewBag.CurrentPage = pageNum;

        return View(joinedData);
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

    // Related Crania Table
    public IActionResult RelatedCrania(int pageNum = 1)
    {

        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        var burial = egyptDbContext.Burials;
        int pageSize = 12;

        IEnumerable<craniaViewModel> joinedCrania = null;

        joinedCrania = (from c in egyptDbContext.Crania
                          join b in burial on c.BurialNumber equals b.BurialNumber into cbGroup
                          from cb in cbGroup.DefaultIfEmpty()
                          select new craniaViewModel
                          {
                              Location = c.Location,
                              BurialNumber = c.BurialNumber,
                              ExcavationYear = c.ExcavationYear,
                              MaxCraniumLength = c.MaxCraniumLength,
                              MaxCraniumBreadth = c.MaxCraniumBreadth,
                              BasionBregmaHeight = c.BasionBregmaHeight,
                              BasionNasionLength = c.BasionNasionLength,
                              BasionProsthionLength = c.BasionProsthionLength,
                              BizygomaticDiameter = c.BizygomaticDiameter,
                              NasionProsthionHeight = c.NasionProsthionHeight,
                              MaxNasalBreadth = c.MaxNasalBreadth,
                              InterorbitalBreadth = c.InterorbitalBreadth,
                              Sex = c.Sex,
                              CalculatedSex = c.CalculatedSex,
                              SexMatch = c.SexMatch,
                              CalcMaxCraniumLength = c.CalcMaxCraniumLength,
                              CalcBasionNasion = c.CalcBasionNasion,
                              CalcBasionProsthion = c.CalcBasionProsthion,
                              CalcBizygomaticDiameter = c.CalcBizygomaticDiameter,
                              CalcNasionProsthionHeight = c.CalcNasionProsthionHeight,
                              CraniumCalcSum = c.CraniumCalcSum,
                              Burial = c.Burial, //NEEDED?
                              CraniumPhotos = c.CraniumPhotos
                          }
            ).OrderBy(x => x.Location)
            .ThenBy(x => x.BurialNumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.CurrentPage = pageNum;

        return View(joinedCrania);
    }

    // Crania Details Page
    public IActionResult CraniaDetails(string BurialNumberID, string Location, string ExcavationYear)

    {
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        //var textileList = egyptDbContext.Textiles.ToList();

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
