using LuvLane.Data.Entities;
using LuvLane.Models.Profile;
using LuvLane.Services.ProfileService;
using Microsoft.AspNetCore.Mvc;

namespace LuvLane.Mvc.Controllers;

public class ProfileController : Controller
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<ProfileListItem> profiles = await _profileService.GetAllProfilesAsync();
        return View(profiles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProfileCreate model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _profileService.CreateProfileAsync(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [ActionName("Info")]
    public async Task<IActionResult> Profile(string id)
    {
        var detail = await _profileService.GetProfileById(id);

        if (detail == null)
            return RedirectToAction(nameof(Index));

        return View(detail);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
            return RedirectToAction(nameof(Index));

        Profile profile = await _profileService.GetProfileHelperMethod(id);

        ProfileEdit profileEdit = new ProfileEdit
        {
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Age = profile.Age,
            Gender = (LuvLane.Models.Profile.Gender)profile.Gender,
            Bio = profile.Bio
        };

        return View(profileEdit);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProfileEdit model, string id)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        await _profileService.UpdateProfile(model, id);
        return RedirectToAction("Info", new { id = id });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        Profile profile = await _profileService.GetProfileHelperMethod(id);

        if (profile == null)
            return RedirectToAction(nameof(Index));

        ProfileDetail profileDetail = new ProfileDetail
        {
            Id = profile.UserId,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Age = profile.Age,
            Gender = (LuvLane.Models.Profile.Gender)profile.Gender,
            Bio = profile.Bio
        };

        return View(profileDetail);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProfileAsync(string id, ProfileDetail model)
    {
        if (id == null)
            return RedirectToAction(nameof(Index));

         await _profileService.DeleteProfileAsync(id);
         return RedirectToAction(nameof(Index));

        
    }
}