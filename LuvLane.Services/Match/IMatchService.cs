using LuvLane.Models.Match;

namespace LuvLane.Services.MatchService;

    public interface IMatchService
    {
        Task<List<MatchListItems>> GetAllMatchesAsync();
        Task<bool> CreateMatchAsync(MatchCreate model);
    }
