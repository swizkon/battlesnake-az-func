using System.Collections.Generic;

namespace anaconda.Model
{

    public class GameState
    {
        public Game Game { get; set; }
        public int Turn { get; set; }
        public Board Board { get; set; }
        public BattleSnake You { get; set; }
    }



    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Point> Food { get; set; }
        public List<Point> Hazards { get; set; }
        public List<BattleSnake> Snakes { get; set; }
    }

    public class Game
    {
        public string Id { get; set; }
        public int Timeout { get; set; }
        public RuleSet RuleSet { get; set; }
    }
}