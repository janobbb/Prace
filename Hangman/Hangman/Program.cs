using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Hangman";
                Console.CursorVisible = false;
                string[] words = new string[] { "Fajne Hasło" }; //Stworzyć klase z hasłami
                string[] hiddenWords = CreateHiddenArray(words);
                List<char> LetterUsed = new List<char>();
                int triesNumber = 3;
                Menu(hiddenWords, words, triesNumber, LetterUsed);

            }
            catch (Exception e)
            {
                Console.WriteLine("Coś poszło nie tak");
                Console.WriteLine(e.Message);
            }
        }
        static void Menu(string[] hiddenWords, string[] words, int triesNumber, List<char> letterUsed)
        {
            Console.WriteLine(">>> Hangman <<<");
            Console.WriteLine("1.Nowa Gra\n2.Zasady Gry\n3.Wyjście");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.Clear();
                Game(hiddenWords, words, triesNumber, letterUsed);
            }
            else if (option == "2")
            {
                Console.Clear();
                GameRules();
                Console.WriteLine("\n\n1.Przejdź do gry\n2.Wróć");
                string optionGameRules = Console.ReadLine();
                if (optionGameRules == "1")
                {
                    Console.Clear();
                    Game(hiddenWords, words, triesNumber, letterUsed);
                }

                else
                {
                    Console.Clear();
                    Menu(hiddenWords, words, triesNumber, letterUsed);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Koniec gry");
            }
        }
        static void GameRules()
        {
            Console.WriteLine("Zasady gry:");
            Console.WriteLine("1.Wpisuj tylko i wyłącznie pojedyńcze litery");
            Console.WriteLine("2.Nie powtarzaj liter bo stracisz życie");
        }
        static string[] CreateHiddenArray(string[] words)
        {
            string[] hidden = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                string text = "";
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (words[i][j] == ' ')
                    {
                        text += words[i][j];
                    }
                    else
                        text += "*";
                    hidden[i] = text;
                }
            }
            return hidden;
        }
        static int CheckHiddenLetters(string[] hiddenArray)
        {
            int hiddenLettersNumber = 0;
            for (int i = 0; i < hiddenArray.Length; i++)
            {
                for (int j = 0; j < hiddenArray[i].Length; j++)
                {
                    if (hiddenArray[i][j] == '*')
                    {
                        hiddenLettersNumber++;
                    }
                }
            }
            return hiddenLettersNumber;
        }
        static void DisplayEndingScene()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.Clear();
                Console.SetCursorPosition(0, i);
                Console.WriteLine("Tworzone przez: Jan Gumułka");
                Thread.Sleep(100);
                Console.Clear();
            }
            Thread.Sleep(500);
            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.WriteLine("Dzięki za gre! :)");
            Console.ReadKey();
        }
        static void DisplayHiddenArray(string[] hiddenArray, int triesNumber, List<char> letterUsed)
        {
            string tries = "Liczba żyć: " + triesNumber;
            foreach (string x in hiddenArray)
            {
                Console.WriteLine($"{x} {tries,20}");
            }
            Console.WriteLine("LITERY UŻYTE:");
            foreach (char x in letterUsed)
            {
                Console.Write($"{x},");
            }
        }

        static string[] ReplaceHiddenArray(string[] hiddenArray, string[] words, int triesNumber, List<char> lettersUsed)
        {
            Console.Write("\n\nPodaj litere do odsłonięcia: ");
            char letter = Convert.ToChar(Console.ReadLine());
            Console.Clear();
            lettersUsed.Add(char.ToLower(letter));
            for (int i = 0; i < hiddenArray.Length; i++)
            {
                string text = "";
                for (int j = 0; j < hiddenArray[i].Length; j++)
                {
                    if (Char.ToUpper(letter) == Char.ToUpper(words[i][j]))
                        text += char.ToUpper(letter);
                    else
                    {
                        text += hiddenArray[i][j];
                    }
                }
                hiddenArray[i] = text;
            }
            DisplayHiddenArray(hiddenArray, triesNumber, lettersUsed);
            return hiddenArray;
        }
        static void Game(string[] hiddenWords, string[] words, int triesNumber, List<char> letterUsed)
        {
            DisplayHiddenArray(hiddenWords, triesNumber, letterUsed);
            int x = CheckHiddenLetters(hiddenWords);
            int y = x;
            while (x > 0)
            {
                ReplaceHiddenArray(hiddenWords, words, triesNumber, letterUsed);
                x = CheckHiddenLetters(hiddenWords);
                if (y == x)
                {
                    triesNumber--;
                    Console.Clear();
                    DisplayHiddenArray(hiddenWords, triesNumber, letterUsed);
                }
                y = x;
                if (triesNumber == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Przegrałeś. Hasło to: {words[0]}");
                    Thread.Sleep(1000);
                    DisplayEndingScene();
                    break;
                }
                if (x == 0)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Wygrałeś");
                    Console.WriteLine($"Hasło to: {words[0]}");
                    Thread.Sleep(1000);
                    DisplayEndingScene();
                }
            }
        }
    }

}