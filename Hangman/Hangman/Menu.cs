using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Menu
    {
        static string[] options = new string[] { "1.Nowa Gra", "2.Zasady Gry", "3.Wyjdź" };
        static int activeMenuPosition = 0;

        public static void StartMenu()
        {
            Console.Title = ">>> BlackJack <<<";
            Console.CursorVisible = false;
            ShowOptions();
            ChooseOption();
            LaunchOption();
        }

        static void ShowOptions()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(">>> BlackJack v 1.0 <<<");
            Console.WriteLine();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == activeMenuPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{options[i],-35}");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.WriteLine(options[i]);
                }
            }
        }
        static void ChooseOption()
        {
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    activeMenuPosition = (activeMenuPosition > 0) ? activeMenuPosition - 1 : options.Length - 1;
                    ShowOptions();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    activeMenuPosition = (activeMenuPosition + 1) % options.Length;
                    ShowOptions();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    activeMenuPosition = options.Length - 1;
                    ShowOptions();
                }
                else if (key.Key == ConsoleKey.Enter)
                    break;
            } while (true);
        }

        static void LaunchOption()
        {
            switch (activeMenuPosition)
            {
                case 0: Console.Clear(); opcjaWBudowie(); break;
                case 1: Console.Clear(); opcjaWBudowie(); break;
                case 2: Environment.Exit(0); break;
            }
        }
        static void opcjaWBudowie()
        {
            Console.WriteLine("Opcja w budowie!!!");
            Console.ReadKey();
        }
    }
}
