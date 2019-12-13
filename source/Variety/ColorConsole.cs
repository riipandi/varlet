using System;

namespace Variety
{
    public abstract class ColorizeConsole
    {
        /// <summary>
        /// Print text with color
        /// </summary>
        public static void PrintSuccess(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void PrintInfo(string value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void PrintWarning(string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(value);
            Console.ResetColor();
        }

        public static void PrintError(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Print line with color
        /// </summary>
        public static void PrintlnSuccess(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }

        public static void PrintlnInfo(string value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }

        public static void PrintlnWarning(string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }

        public static void PrintlnError(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }
    }
}
