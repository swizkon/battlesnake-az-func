namespace anaconda.Model
{
    public class GameState
    {
        public Game Game { get; set; }
        public int Turn { get; set; }
        public Board Board { get; set; }
        public BattleSnake You { get; set; }
    }
}