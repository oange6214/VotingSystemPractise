namespace VotingSystem.Models
{
    public class VotingPoll
    {
        public VotingPoll()
        {
            Counters = new List<Counter>();
        }

        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Counter> Counters { get; set; }
    }
}
