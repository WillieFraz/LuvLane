using LuvLane.Models.Profile;
using LuvLane.Data.Entities;
using Microsoft.EntityFrameworkCore;
using LuvLane.Data;
using Microsoft.AspNetCore.Identity;
using Azure.Identity;
using System.ComponentModel.Design.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace LuvLane.Services.ProfileService;

public class ProfileService : IProfileService
{
    private readonly ApplicationDbContext _dbcontext;
    private readonly string _userId;
    // private readonly UserManager<UserEntity> _userManager;
    // private readonly SignInManager<UserEntity> _signInManager;

    public ProfileService(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        // SetUserId(userManager, signInManager);
        // _userManager = userManager;
        // _signInManager = signInManager;
        var currentUser = signInManager.Context.User;
        _userId = userManager.GetUserId(currentUser);
        _dbcontext = dbContext;
    }

    public async Task<bool> CreateProfileAsync(ProfileCreate model)
    {
        //   SetUserId(_userManager, _signInManager);

        Profile profile = new Profile()
        {
            UserId = _userId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Age = model.Age,
            Bio = model.Bio,
            Gender = (Data.Entities.Gender)model.Gender,
            Location = "Not yet set"
        };

        _dbcontext.Profile.Add(profile);
        return await _dbcontext.SaveChangesAsync() == 1;

    }

    public async Task<List<ProfileListItem>> GetAllProfilesAsync()
    {
        List<ProfileListItem> profile = await _dbcontext.Profile
            .Select(entity => new ProfileListItem
            {
                Id = entity.UserId,
                FirstName = entity.FirstName,
                Age = entity.Age,
                Gender = (Models.Profile.Gender)entity.Gender
            })
            .ToListAsync();

        return profile;
    }

    public async Task<bool> DeleteProfileAsync(string id)
    {
        var profile = await _dbcontext.Profile.FindAsync(id);

        if (profile.UserId != id)
            return false;

        _dbcontext.Profile.Remove(profile);
        return await _dbcontext.SaveChangesAsync() == 1;
    }

    public async Task<ProfileDetail?> GetProfileById(string id)
    {
        var profile = await _dbcontext.Profile
            .FirstOrDefaultAsync(p => p.UserId == id);

        if (profile == null)
            return null;

        ProfileDetail profileDetail = new ProfileDetail()
        {
            Id = profile.UserId,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Age = profile.Age,
            Gender = (Models.Profile.Gender)profile.Gender,
            Bio = profile.Bio
        };

        return profileDetail;
    }

    public async Task<bool> UpdateProfile(ProfileEdit editedProfile, string id)
    {
        if (id == null)
            return false;

        Profile profile = await GetProfileHelperMethod(id);

        if (editedProfile.FirstName != "")
        {
            profile!.FirstName = editedProfile.FirstName;
        }

        if (editedProfile.LastName != "")
        {
            profile!.LastName = editedProfile.LastName;
        }

        if (editedProfile.Bio != "")
        {
            profile!.Bio = editedProfile.Bio;
        }
        await _dbcontext.SaveChangesAsync();

        return true;
    }

    public async Task<Profile> GetProfileHelperMethod(string id)
    {
        Profile profile = await _dbcontext.Profile.FindAsync(id);
        return profile;
    }
}
