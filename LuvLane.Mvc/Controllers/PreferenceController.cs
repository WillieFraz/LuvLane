using LuvLane.Data.Entities;
using LuvLane.Models.Preference;
using LuvLane.Services.PreferencesService;
using Microsoft.AspNetCore.Mvc;

namespace LuvLane.Mvc.Controllers;

public class PreferenceController : Controller
{
    private readonly IPreferenceService _preferenceService;
    public PreferenceController(IPreferenceService preferenceService)
    {
        _preferenceService = preferenceService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PreferenceCreate model)
    {
        if (!ModelState.IsValid)
            return View(ModelState);

        await _preferenceService.CreatePreferanceAsync(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<PreferenceListItem> preferences = await _preferenceService.GetAllPreferencesAsync();
        return View(preferences);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        Preferences preference = await _preferenceService.GetPreferenceHelperMethod(id);

        if (preference == null)
            return RedirectToAction(nameof(Index));

        PreferenceDetail preferenceDetail = new PreferenceDetail
        {
            HighestAgeRange = preference.HighestAgeRange,
            LowestAgeRange = preference.LowestAgeRange,
            Gender = (LuvLane.Models.Profile.Gender)preference.Gender
        };

        return View(preferenceDetail);
    }

    [HttpPost]
    public async Task<IActionResult> DeletePreferenceAsync(string id)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        await _preferenceService.DeletePreferenceAsync(id);
        return RedirectToAction(nameof(Index));
    }

}
