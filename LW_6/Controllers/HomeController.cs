using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LW_6.Models;

namespace LW_6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Page1()
    {
        List<BarModel> bars = new List<BarModel>();

        using (var db = new DemoContext())
        {
            bars = db.Bars.ToList();
            if (bars.Count > 0)
            {
                for (int i = 0; i < bars.Count; i++)
                {
                   db.Remove(bars[i]); 
                }
            }
            db.SaveChanges();
        }

        List<string> barsList = new List<string>();
        for (int i = 0; i < bars.Count; i++)
        {
            barsList.Add(bars[i].Text);
        }

        ViewBag.bars = barsList;
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    public IActionResult Index(BarModel bar)
    {
        using (var db = new DemoContext())
        {
            db.Add(bar);
            db.SaveChanges();
        }
        return View();
    }
}