using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Utils
{
    public static class Logger
    {
        public static void PrintMessage(string message) => Console.Write(message);
        public static void PrintLineMessage(string message) => Console.WriteLine(message);
        public static void PrintParaGraphSeparatorMessage(string message) => Console.WriteLine("=============================================================");
        public static void PrintLineGreenTextMessage(string message) => PrintLineColoredMessage(ConsoleColor.Green, message);
        public static void PrintLineRedTextMessage(string message) => PrintLineColoredMessage(ConsoleColor.Red, message);
        public static void PrintLineCyanTextMessage(string message) => PrintLineColoredMessage(ConsoleColor.Cyan, message);
        public static void PrintLineYellowTextMessage(string message) => PrintLineColoredMessage(ConsoleColor.Yellow, message);

        public static void PrintLineHighLightedMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void PrintLineColoredMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
