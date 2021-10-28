using System.Collections.Generic;
using System.Linq;
using Anaconda.Domain.Model;
using Microsoft.Extensions.Logging;

namespace Anaconda.Domain
{
    public static class DecisionMaker
    {
        public static MoveResponse CalculateMove(GameState state, ILogger logger)
        {
            // char[][] board = new char[state.Board.Width][state.Board.Height];

            logger.LogInformation("Health: {Health}", state.You.Health);
            var possibleMoves = GetInitialPossibleMoves(state).ToList();

            if (!possibleMoves.Any())
                logger.LogWarning("No possible moves detected...");
            else if (possibleMoves.Count == 1)
                logger.LogWarning("Only one move detected: {@Moves}", possibleMoves);
            else 
                logger.LogInformation("Possible moved and rank: {@Moves}", possibleMoves);

            var moves = possibleMoves
                .OrderByDescending(x => x.Value)
                // .ThenByDescending(x => new Random().Next())
                .ToList();

            var move = moves.FirstOrDefault();
            return new MoveResponse
            {
                Move = move.Key,
                Shout = $"Im moving {move.Key} with score {move.Value}"
            };
        }

        private static IEnumerable<KeyValuePair<Moves, decimal>> GetInitialPossibleMoves(GameState gameState)
        {
            var myHead = gameState.You.Head;
            var myNeck = gameState.You.Body[1];

            if (myHead.Y >= myNeck.Y 
                && myHead.Y < gameState.Board.Height - 1
                && !gameState.You.Body.Any(b => b.X == myHead.X && b.Y == myHead.Y + 1))
                yield return new KeyValuePair<Moves, decimal>(Moves.Up, 0);

            if (myHead.Y <= myNeck.Y 
                && myHead.Y > 0
                && !gameState.You.Body.Any(b => b.X == myHead.X && b.Y == myHead.Y - 1))
                yield return new KeyValuePair<Moves, decimal>(Moves.Down, 0);

            if (myHead.X <= myNeck.X 
                && myHead.X > 0
                && !gameState.You.Body.Any(b => b.Y == myHead.Y && b.X == myHead.X - 1))
                yield return new KeyValuePair<Moves, decimal>(Moves.Left, 0);
            
            if (myHead.X >= myNeck.X 
                && myHead.X < gameState.Board.Width - 1
                && !gameState.You.Body.Any(b => b.Y == myHead.Y && b.X == myHead.X + 1))
                yield return new KeyValuePair<Moves, decimal>(Moves.Right, 0);
        }
    }
}