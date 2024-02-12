﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BYU_EGYPT.Models;

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
        ByuEgyptDbContext egyptDbContext = new ByuEgyptDbContext();
        
        var c14List = egyptDbContext.C14s.ToList();
     
        return View(c14List);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Data()
    {
        return View();
    }

<<<<<<< Updated upstream
    public IActionResult Search()
=======
    public IActionResult Test()
>>>>>>> Stashed changes
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

