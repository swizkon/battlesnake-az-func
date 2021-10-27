using System.Collections.Generic;

namespace Anaconda.Domain.Model
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Point> Food { get; set; }
        public List<Point> Hazards { get; set; }
        public List<BattleSnake> Snakes { get; set; }
    }
}