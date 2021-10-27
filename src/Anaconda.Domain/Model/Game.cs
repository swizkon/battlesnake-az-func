namespace Anaconda.Domain.Model
{
    public class Game
    {
        public string Id { get; set; }
        public int Timeout { get; set; }
        public RuleSet RuleSet { get; set; }
    }
}