using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomGuess.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;

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
        string key = HttpContext.Session.GetString("Level");
        switch (key)
        {
            case "Easy":
            {
                ViewData["Level"] = DifficultyLevel.Easy;
                return View("RandomGuessLevel");
            }
            case "Medium":
            {
                ViewData["Level"] = DifficultyLevel.Medium;
                return View("RandomGuessLevel");
            }
            case "Hard":
            {
                ViewData["Level"] = DifficultyLevel.Hard;
                return View("RandomGuessLevel");

            }
            default:
                return View();

        }
    }

    public IActionResult Easy()
    {
        Random rand = new Random();
        int answer = rand.Next(1,10);

        HttpContext.Session.SetInt32("answer" , answer);
        
        HttpContext.Session.SetString("Level", DifficultyLevel.Easy.ToString());

        // relocate the viewdata to be in the index action class
        //ViewData["Level"] = DifficultyLevel.Easy;

        // Even though the route is "/Easy", return
        // the view template "RandomGuessLevel" since it's dynamic.
        return RedirectToAction("Index");
    }

    public IActionResult Medium()
    {
        Random rand = new Random();

        int answer = rand.Next(1,100);

        HttpContext.Session.SetInt32("answer" , answer);

        HttpContext.Session.SetString("Level", DifficultyLevel.Medium.ToString());

        return RedirectToAction("Index");
    }

    public IActionResult Hard()
    {
        Random rand = new Random();
        int answer = rand.Next(1,1000);
        
        HttpContext.Session.SetInt32("answer" , answer);

        HttpContext.Session.SetString("Level", DifficultyLevel.Hard.ToString());

        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Answer(int guess, DifficultyLevel level)
    {
        int answer = HttpContext.Session.GetInt32("answer")
            ?? throw new InvalidOperationException("Expected to find 'answer' stored in the session as an integer, but did not find one.");

        ComparisonResult result = SimpleRandom.CheckGuess(level, answer, guess);
        ViewData["Level"] = level;

        switch (result)
        {
            case ComparisonResult.Equal:
                HttpContext.Session.SetString("Level", "right");
                return Redirect("/");
            case ComparisonResult.TooLow:
                TempData["Message"] = "Try Again";
                TempData["Help"] = "Too Low";

                // Even though level is an Enum, using it here means it will call
                // level.toString() so if level is "DifficultyLevel.Easy", then 
                // the statement is 'return View("Easy")' with would map to "easy.cshtml"
                return View("RandomGuessLevel");
                // return Redirect(level.ToString());
            case ComparisonResult.TooHigh:
                TempData["Message"] = "Try Again";
                TempData["Help"] = "Too High";
                return View("RandomGuessLevel");
                // return Redirect(level.ToString());
            default:
                throw new InvalidOperationException($"Unsupported comparison result {result} for level {level} with guess {guess} and answer {answer}");

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
