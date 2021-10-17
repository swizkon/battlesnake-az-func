using System.Collections.Generic;

namespace anaconda.Model
{
    public class BattleSnake
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public Point Head { get; set; }
        public List<Point> Body { get; set; }
        public string Latency { get; set; }
        public int Length { get; set; }
        public string Shout { get; set; }
        public string Squad { get; set; }
    }
}