using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Game
{
    public class WinGameWithTwoInARowPointsStrategy : WinGameStrategy
    {

        public override (bool CurrentPlayerWon, WinGameStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player scorringPlayer, Player opponent)
        {
            if (scorringPlayer == previousScorringPlayer)
            {
                //Player wins the game
                return (true, new StandardWinGameStrategy());
            }
            else
            {
                //Game continues
                return (false, this);
            }
        }
    }
}
