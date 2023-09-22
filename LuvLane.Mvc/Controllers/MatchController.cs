using LuvLane.Models.Match;
using LuvLane.Services.MatchService;
using Microsoft.AspNetCore.Mvc;

namespace LuvLane.Mvc.Controllers;

public class MatchController : Controller
{
    private readonly IMatchService _matchService;
    public MatchController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<MatchListItems> matches = await _matchService.GetAllMatchesAsync();
        return View(matches);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }


    /*   public async Task<IActionResult> AddMatch(string button, List<UserEntity> users )
       {

       }
   */
}
