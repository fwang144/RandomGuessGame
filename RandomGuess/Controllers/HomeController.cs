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
        string? key = HttpContext.Session.GetString("Level");
        ViewData["key"] = key;
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
            case "Insane":
            {
                ViewData["Level"] = DifficultyLevel.Insane;
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
        HttpContext.Session.SetInt32("Tries", 0); // Reset tries
        return RedirectToAction("Index");
    }

    public IActionResult Medium()
    {
        Random rand = new Random();
        int answer = rand.Next(1,100);
        HttpContext.Session.SetInt32("answer" , answer);
        HttpContext.Session.SetString("Level", DifficultyLevel.Medium.ToString());
        HttpContext.Session.SetInt32("Tries", 0); // Reset tries
        return RedirectToAction("Index");
    }

    public IActionResult Hard()
    {
        Random rand = new Random();
        int answer = rand.Next(1,1000);
        HttpContext.Session.SetInt32("answer" , answer);
        HttpContext.Session.SetString("Level", DifficultyLevel.Hard.ToString());
        HttpContext.Session.SetInt32("Tries", 0); // Reset tries
        return RedirectToAction("Index");
    }

    public IActionResult Insane()
    {
        Random rand = new Random();
        int answer = rand.Next(1,100000);
        HttpContext.Session.SetInt32("answer" , answer);
        HttpContext.Session.SetString("Level", DifficultyLevel.Insane.ToString());
        HttpContext.Session.SetInt32("Tries", 0); // Reset tries
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Answer(int guess, DifficultyLevel level)
    {
        int answer = HttpContext.Session.GetInt32("answer")
            ?? throw new InvalidOperationException("Expected to find 'answer' stored in the session as an integer, but did not find one.");

        string? key = HttpContext.Session.GetString("Level");
        ViewData["key"] = key;
        ComparisonResult result = SimpleRandom.CheckGuess(level, answer, guess);
        ViewData["Level"] = level;

        int tries = HttpContext.Session.GetInt32("Tries") ?? 0;
        if (result == ComparisonResult.Equal)
        {
            TempData["Message"] = "Correct!";
            TempData["Reset"] = "Would you like to reset?";
            TempData["Tries"] = tries + 1; // Show final try count
            HttpContext.Session.SetInt32("Tries", 0); // Reset tries after win
            return View("RandomGuessLevel");
        }
        else
        {
            tries++;
            HttpContext.Session.SetInt32("Tries", tries);
            TempData["Tries"] = tries;
            TempData["Message"] = "Try Again";
            TempData["Help"] = result == ComparisonResult.TooLow ? "Too Low" : "Too High";
            return View("RandomGuessLevel");
        }
    }
    [HttpPost]
    public IActionResult Reset()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
