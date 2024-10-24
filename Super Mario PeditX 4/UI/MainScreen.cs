using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;


namespace Super_Mario_PeditX_4.UI
{
    public class MainScreen
    {
        // Импортируем функцию для разворачивания окна
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_MAXIMIZE = 3;

        public static void LoadMainScreen()
        {
            // Разворачиваем консоль на весь экран
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            // Отключаем мигающий курсор
            Console.CursorVisible = false;

            Thread.Sleep(1000);// Пауза перед показом команды

            // Чтение ASCII-изображения из файла intro.txt и вывод на консоль
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UI", "Team-presentation.txt");
            DrawFrame();
            DisplayIntro(filePath);

            Thread.Sleep(2500);// Пауза после показа команды

            
            //Console.WriteLine("\nPress any key to start the animation...");
            //Console.ReadKey();

            // Исходный текст в ASCII для анимации
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
            "     ░                 ░            ░              By Penis Studio "
        };

            // Создаем список всех позиций символов
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

            // Перемешиваем позиции для случайного порядка
            Random rand = new Random();
            positions = positions.OrderBy(_ => rand.Next()).ToList();

            // Определим общее время анимации и задержку между символами
            int totalDurationMs = 1000; // 1 секунда
            int delayMs = Math.Max(1, totalDurationMs / positions.Count);

            // Пустой массив для отображения
            char[,] displayed = new char[text.Length, text[0].Length];
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    displayed[i, j] = ' ';
                }
            }

            

            // Постепенное отображение символов
            Console.Clear();
            DrawFrame();
            // Рассчитываем отступы для центрирования текста
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int startX = (windowWidth - text[0].Length) / 2;
            int startY = (windowHeight - text.Length) / 2;

            foreach (var (y, x) in positions)
            {
                displayed[y, x] = text[y][x];
                Console.SetCursorPosition(startX + x, startY + y);
                Console.Write(displayed[y, x]);
                Thread.Sleep(delayMs); // Задержка для эффекта появления
            }

            // Включаем мигающий курсор после завершения анимации
            Console.CursorVisible = true;




            // Рассчитываем позицию для сообщения "To play press enter"
            int lastLineLength = text[text.Length - 1].Length;

            // Рассчитываем позицию X для центрирования текста "To play press enter"
            int playTextX = (Console.WindowWidth - "To play press enter".Length) / 2;

            // Рассчитываем позицию Y для строки, которая будет сразу под последней строкой ASCII
            int playTextY = startY + text.Length + 2; // "+ 2" чтобы добавить отступ

            // Устанавливаем курсор в нужное место
            Console.SetCursorPosition(playTextX, playTextY);

            // Выводим текст для начала игры
            Console.WriteLine("To play press enter");



            // Получаем ширину и высоту окна консоли в символах
            //int width = Console.WindowWidth;
            //int height = Console.WindowHeight;

            //Console.WriteLine($"Ширина окна: {width} символов");
            //Console.WriteLine($"Высота окна: {height} символов");
            //Console.WriteLine($"Общее количество символов в окне: {width * height}");

            // Ждем нажатия клавиши Enter
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

            Console.Clear();



        }

        static void DisplayIntro(string filePath)
        {
            try
            {
                // Чтение строк из файла
                var lines = File.ReadAllLines(filePath);

                // Рассчитываем отступы для центрирования изображения по вертикали
                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;
                int startY = (windowHeight - lines.Length) / 2;

                // Выводим каждую строку с отступом по центру
                foreach (var line in lines)
                {
                    int startX = (windowWidth - line.Length) / 2;
                    Console.SetCursorPosition(startX, startY++);
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading intro file: {ex.Message}");
            }
        }


        public static void DrawFrame()
        {
            int width = 150;  // Ширина рамки
            int height = 40;  // Высота рамки

            // Рассчитываем отступы, чтобы рамка была по центру консольного окна
            int startX = (Console.WindowWidth - width) / 2;
            int startY = (Console.WindowHeight - height) / 2;

            // Отрисовка верхней границы
            Console.SetCursorPosition(startX, startY);
            Console.Write("+" + new string('-', width - 2) + "+");

            // Отрисовка боковых границ
            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                Console.Write("|" + new string(' ', width - 2) + "|");
            }

            // Отрисовка нижней границы
            Console.SetCursorPosition(startX, startY + height - 1);
            Console.Write("+" + new string('-', width - 2) + "+");
        }
    }
}