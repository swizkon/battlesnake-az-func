using System;
using System.Collections.Generic;
using System.Linq;
using anaconda.Model;
using Microsoft.Extensions.Logging;

namespace anaconda.Domain
{
    public static class DecisionMaker
    {
        public static MoveResponse CalculateMove(GameState state, ILogger logger)
        {
            var possibleMoves = GetInitialPossibleMoves(state).ToList();

            //let possibleMoves = {
            //    up: true,
            //    down: true,
            //    left: true,
            //    right: true
            //}


            logger.LogInformation("Possible moved and rank: {@Moves}", possibleMoves);

            var moves = possibleMoves
                .ToList()
                .OrderByDescending(x => x.Value)
                // .ThenByDescending(x => new Random().Next())
                .ToList();

            if (!moves.Any())
            {
                logger.LogWarning("No possible moves detected...");
            }

            return new MoveResponse
            {
                Move = moves.FirstOrDefault().Key,
                Shout = "Im moving {move}"
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