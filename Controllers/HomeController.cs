using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using TheScouts.Models;
using TheScouts.Repositories;
using TheScouts.Services;
using Microsoft.Extensions.Logging;
using System;

namespace TheScouts.Controllers;

public class HomeController : Controller
{
    private readonly IPositionService _service;

    public HomeController(IPositionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var positions = await _service.GetAllAsync();
        return View(positions);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

