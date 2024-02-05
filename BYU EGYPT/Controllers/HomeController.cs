using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BYU_EGYPT.Models;
using BYU_EGYPT.DataObjects;

namespace BYU_EGYPT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        EgyptDbContext egyptDbContext = new EgyptDbContext();
        
        var testTableList = egyptDbContext.TestTables.ToList();
        var c14List = egyptDbContext.C14s.ToList();

        return View(testTableList);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Data()
    {
        return View();
    }

    public IActionResult Search()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

