using LuvLane.Data;
using LuvLane.Data.Entities;
using LuvLane.Models.Match;
using LuvLane.Models.Profile;
using Microsoft.EntityFrameworkCore;

namespace LuvLane.Services.MatchService;

public class MatchService : IMatchService
{
    private readonly ApplicationDbContext _context;
    public MatchService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> CreateMatchAsync(MatchCreate model)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MatchListItems>> GetAllMatchesAsync()
    {
        List<MatchListItems> matches = await _context.Match
            .Select(entity => new MatchListItems
            {
                MatchId = entity.MatchId,
                UserTwoId = entity.UserTwoId,
                MatchStatus = entity.MatchStatus,
                CreatedAt = entity.CreatedAt
        
            })
            .ToListAsync();

        return matches;
    }
}


/*    public async Task<bool> CreateMatchAsync(MatchCreate model)
    {

    }

*/
