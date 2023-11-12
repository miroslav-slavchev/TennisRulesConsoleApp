using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Match
{
    public class BestOfThreeWinMatchStrategy : WinMatchStrategy
    {
        public override bool CheckWin(Player setWinner, Player opponent)
        {
            if (setWinner.Score.Sets == 2)
            {
                // Player wins
                return true;
            }
            else
            {
                // Match continues
                return false;
            }
        }
    }
}
