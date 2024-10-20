using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.UI
{
    public class MainScreen
    {

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_MAXIMIZE = 3;

        static void LoadMainScreen()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            string[] text = {
            " ██▒   █▓ ▒█████   ██▓▓█████▄  ▄▄▄▄    ▒█████   ██▀███   ███▄    █ ",
            "▓██░   █▒▒██▒  ██▒▓██▒▒██▀ ██▌▓█████▄ ▒██▒  ██▒▓██ ▒ ██▒ ██ ▀█   █ ",
            " ▓██  █▒░▒██░  ██▒▒██▒░██   █▌▒██▒ ▄██▒██░  ██▒▓██ ░▄█ ▒▓██  ▀█ ██▒",
            "  ▒██ █░░▒██   ██░░██░░▓█▄   ▌▒██░█▀  ▒██   ██░▒██▀▀█▄  ▓██▒  ▐▌██▒",
            "   ▒▀█░  ░ ████▓▒░░██░░▒████▓ ░▓█  ▀█▓░ ████▓▒░░██▓ ▒██▒▒██░   ▓██░",
            "   ░ ▐░  ░ ▒░▒░▒░ ░▓   ▒▒▓  ▒ ░▒▓███▀▒░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░ ▒░   ▒ ▒ ",
            "   ░ ░░    ░ ▒ ▒░  ▒ ░ ░ ▒  ▒ ▒░▒   ░   ░ ▒ ▒░   ░▒ ░ ▒░░ ░░   ░ ▒░",
            "     ░░  ░ ░ ░ ▒   ▒ ░ ░ ░  ░  ░    ░ ░ ░ ░ ▒    ░░   ░    ░   ░ ░ ",
            "      ░      ░ ░   ░     ░     ░          ░ ░     ░              ░ ",
            "     ░                 ░            ░               By Penis Studio"
        };

            List<(int, int)> positions = new List<(int, int)>();
            for (int y = 0; y < text.Length; y++)
            {
                for (int x = 0; x < text[y].Length; x++)
                {
                    if (text[y][x] != ' ')
                    {
                        positions.Add((y, x));
                    }
                }
            }

            Random rand = new Random();
            positions = positions.OrderBy(_ => rand.Next()).ToList();

            int totalDurationMs = 1000;
            int delayMs = Math.Max(1, totalDurationMs / positions.Count);

            char[,] displayed = new char[text.Length, text[0].Length];
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    displayed[i, j] = ' ';
                }
            }

            Console.CursorVisible = false;

            Console.Clear();

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int startX = (windowWidth - text[0].Length) / 2;
            int startY = (windowHeight - text.Length) / 2;

            foreach (var (y, x) in positions)
            {
                displayed[y, x] = text[y][x];
                Console.SetCursorPosition(startX + x, startY + y);
                Console.Write(displayed[y, x]);
                Thread.Sleep(delayMs);
            }

            Console.CursorVisible = true;

            Console.SetCursorPosition(0, startY + text.Length + 2);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
