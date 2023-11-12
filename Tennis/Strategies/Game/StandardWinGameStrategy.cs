using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Game
{
    public class StandardWinGameStrategy : WinGameStrategy
    {


        public override (bool CurrentPlayerWon, WinGameStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player scorringPlayer, Player opponent)
        {
            CheckInvalidData(scorringPlayer, opponent);

            if (scorringPlayer.Score.Points == 4 && opponent.Score.Points < 3)
            {
                //Player wins.
                return (true, this);
            }
            else if (scorringPlayer.Score.Points == 3 && opponent.Score.Points == 3)
            {
                // First player to score two points in a row - wins the game.
                PrintInfoMessage("First player to score two points in a row - wins the game.");
                return (false, new WinGameWithTwoInARowPointsStrategy());
            }
            else
            {
                // The game continues
                return (false, this);
            }
        }

        private void CheckInvalidData(Player player1, Player player2)
        {
            if (player1.Score.Points > 4 || player2.Score.Points > 4)
            {
                throw new Exception("Something went wrong with the Calculations.");
            }
        }
    }
}
