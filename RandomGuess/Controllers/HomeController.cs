using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomGuess.Models;
using Microsoft.AspNetCore.Http;

namespace RandomGuess.Controllers;

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

    public IActionResult Easy()
    {
        Random rand = new Random();
        int answer = rand.Next(1,10);

        HttpContext.Session.SetInt32("answer" , answer);

        return View();
    }

    public IActionResult Medium()
    {
        Random rand = new Random();

        int answer = rand.Next(1,100);

        HttpContext.Session.SetInt32("answer" , answer);

        return View();
    }

    public IActionResult Hard()
    {
        Random rand = new Random();
        int answer = rand.Next(1,1000);
        HttpContext.Session.SetInt32("answer" , answer);

        return View();
    }
    [HttpPost]
    public IActionResult Answer(int inputAnswer, string level)
    {

        int? keyAnswer = HttpContext.Session.GetInt32("answer");
        if (inputAnswer == keyAnswer)
        {

            return Redirect("/"); 
            
        }
        else
        {   
            TempData["Message"] = "Try Again";

            if (inputAnswer < keyAnswer)
            {
                TempData["Help"] = "Too Low";
            }
            else
            {

                TempData["Help"] = "Too High";
            }

            if (level == "Easy")
            {
                
                return View("Easy");
            }
            else if (level == "Medium")
            {
                return View("Medium");
            }
            else 
            {
                return View("Hard");
            }
  
        }
        
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
}
