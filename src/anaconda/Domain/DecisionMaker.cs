using anaconda.Model;
using Microsoft.Extensions.Logging;

namespace anaconda.Domain
{
    public static class DecisionMaker
    {
        public static MoveResponse CalculateMove(GameState state, ILogger logger)
        {
            //let possibleMoves = {
            //    up: true,
            //    down: true,
            //    left: true,
            //    right: true
            //}

            return new MoveResponse
            {
                Move = Moves.Up,
                Shout = "Im moving {move}"
            };
        }
    }
    
    public enum Moves
    {
        Up,
        Down,
        Left,
        Right
    }
}