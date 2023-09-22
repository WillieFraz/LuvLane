namespace LuvLane.Models.Match;

    public class MatchListItems
    {
        public int MatchId { get; set; }

        public string UserTwoId{ get; set; }

        public string MatchStatus { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

    }
