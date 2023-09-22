using System.Security.Claims;
using LuvLane.Data.Entities;
using LuvLane.Models.Profile;

namespace LuvLane.Services.ProfileService;

    public interface IProfileService
    {
        Task<bool> CreateProfileAsync(ProfileCreate model);
        Task<List<ProfileListItem>> GetAllProfilesAsync();
        Task<ProfileDetail> GetProfileById(string id);
        Task<bool> DeleteProfileAsync(string id);
        Task<bool> UpdateProfile(ProfileEdit editedProfile, string id);
        Task<Profile> GetProfileHelperMethod(string id);
}
