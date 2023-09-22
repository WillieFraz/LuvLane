using LuvLane.Data;
using LuvLane.Data.Entities;
using LuvLane.Models.Preference;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LuvLane.Services.PreferencesService;

public class PreferenceService : IPreferenceService
{
    private readonly ApplicationDbContext _dbcontext;
    private readonly string _userId;
    
    public PreferenceService(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        var currentUser = signInManager.Context.User;
        _userId = userManager.GetUserId(currentUser);
        _dbcontext = dbContext;
    }

    public async Task<bool> CreatePreferanceAsync(PreferenceCreate model)
    {
        Preferences preferences = new()
        {
            HighestAgeRange = model.HighestAgeRange,
            LowestAgeRange = model.LowestAgeRange,
            Gender = (Gender)model.Gender
        };

        _dbcontext.Preference.Add(preferences);
        return await _dbcontext.SaveChangesAsync() == 1;
    }

    public async Task<List<PreferenceListItem>> GetAllPreferencesAsync()
    {
        List<PreferenceListItem> preference = await _dbcontext.Preference
            .Select(entity => new PreferenceListItem
            {
                HighestAgeRange = entity.HighestAgeRange,
                LowestAgeRange = entity.LowestAgeRange,
                Gender = (Models.Profile.Gender)entity.Gender
            })
            .ToListAsync();

        return preference;
    }

    public async Task<bool> DeletePreferenceAsync(string id)
    {
        var preference = await _dbcontext.Preference.FindAsync(id);

        if (preference.UserPreferenceId != id)
            return false;

        _dbcontext.Preference.Remove(preference);
        return await _dbcontext.SaveChangesAsync() == 1;
    }

    public async Task<PreferenceDetail?> GetPreferenceByIdAsync(string id)
    {
        var preference = await _dbcontext.Preference
            .FirstOrDefaultAsync(p => p.UserPreferenceId == id);

        if ( preference == null)
            return null;

        return new PreferenceDetail()
        {
            HighestAgeRange = preference.HighestAgeRange,
            LowestAgeRange = preference.LowestAgeRange,
            Gender = (Models.Profile.Gender)preference.Gender
        };
    }

    public async Task<Preferences> GetPreferenceHelperMethod(string id)
    {
        Preferences preference = await _dbcontext.Preference.FindAsync(id);
        return preference;
    }

}
