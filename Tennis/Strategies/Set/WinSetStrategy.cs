using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Set
{
    public abstract class WinSetStrategy
    {
        public abstract (bool CurrentPlayerWon, WinSetStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player currentScorringPlayer, Player opponent);

        protected void PrintInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
