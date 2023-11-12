using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Game
{
    public abstract class WinGameStrategy
    {
        public abstract (bool CurrentPlayerWon,WinGameStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player scorringPlayer, Player opponent);

        protected void PrintInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
