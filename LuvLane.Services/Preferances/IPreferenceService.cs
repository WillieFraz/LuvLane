using LuvLane.Data.Entities;
using LuvLane.Models.Preference;

namespace LuvLane.Services.PreferencesService;

    public interface IPreferenceService
    {
        Task<bool> CreatePreferanceAsync(PreferenceCreate model);
        Task<List<PreferenceListItem>> GetAllPreferencesAsync();
        Task <bool> DeletePreferenceAsync(string id);
        Task<PreferenceDetail> GetPreferenceByIdAsync(string id);
        Task<Preferences> GetPreferenceHelperMethod(string id);
    }
