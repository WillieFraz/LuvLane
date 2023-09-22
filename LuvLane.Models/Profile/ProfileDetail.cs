namespace LuvLane.Models.Profile;

    public class ProfileDetail
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Bio { get; set; } = string.Empty;
    }
