using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if(wrong == 1)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine(" /|   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if (wrong == 7)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine("  |   |");
                Console.WriteLine(" /    |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }
            else if (wrong == 8)
            {
                Console.WriteLine("\n+----+");
                Console.WriteLine("  0   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine("  |   |");
                Console.WriteLine(" / \\ |");
                Console.WriteLine("      |");
                Console.WriteLine("    =====");
            }

        }

        private static int printWord(List<char> guessLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.WriteLine("\r\n");
            foreach (char c in guessLetters)
            {
                if (guessLetters.Contains(c))
                {
                    Console.WriteLine(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.WriteLine(" ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.WriteLine("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("       Welcome To Hangman     ");
            Console.WriteLine("------------------------------------------");

            Random random = new Random();
            List<String> words = new List<String> { "brave" , "youtube" , "management" , "keyboard" , "surfing" , "computer" , "project" , "appointment" , "website" , "apple" , "orange"};
            int index = random.Next(words.Count);
            String randomWord = words[index];

            foreach (char x in randomWord)
            {
                Console.WriteLine("_ ");
            }

            int lengthOfWordGuess = randomWord.Length;
            int amoutOfTimesWrong = 0;
            List<char> currentLettersGueesed = new List<char>();
            int currentLettersRight = 0;

            while(amoutOfTimesWrong != 8 && currentLettersRight != lengthOfWordGuess)
            {
                Console.WriteLine("\nLetters Guessed So Far: ");
                foreach(char letter in currentLettersGueesed)
                {
                    Console.WriteLine(letter + " ");
                }
                Console.WriteLine("\nGuess A Letter: ");
                char letterGueesed = Console.ReadLine()[0];

                if (currentLettersGueesed.Contains(letterGueesed))
                {
                    Console.WriteLine("\r\nYou have already guessed this letter.");
                    printHangman(amoutOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGueesed , randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if(letterGueesed == randomWord[i]) { right = true;  }
                    }
                    if (right)
                    {
                        printHangman(amoutOfTimesWrong);
                        currentLettersGueesed.Add(letterGueesed);
                        currentLettersRight = printWord(currentLettersGueesed, randomWord);
                        Console.WriteLine("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amoutOfTimesWrong++;
                        currentLettersGueesed.Add(letterGueesed);
                        printHangman(amoutOfTimesWrong);
                        currentLettersRight = printWord(currentLettersGueesed, randomWord);
                        Console.WriteLine("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame Over!!! Thanks For Playing");
        }
    }
}