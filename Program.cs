using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] wordbank = { "haris", "gusinac", "ulf", "ammara", "huskvarna" };// random ord

            Random random = new Random();
            string wordToguess = wordbank[random.Next(wordbank.Length)]; // Random Ord att gissa


            /*StringBuilder displayToPlayer = new StringBuilder();//Se över (wordToGuess.Length)
            for (int i = 0; i < wordToguess.Length; i++)
                displayToPlayer.Append('_');*/



            char[] correctGuesses = new char[wordToguess.Length];// Gör om till  Arrays 
            Array.Fill<char>(correctGuesses, '_');

            StringBuilder incorrectGuesses = new StringBuilder();// fel gissningar

            // List<char> incorrectGuesses = new List<char>();// Gör om till String builder Arrays 

            int lives = 10;
            bool won = false;

            string input;
            char guess;

            Console.WriteLine($"Lives left :{lives}");

            foreach (char c in correctGuesses)
            {
                Console.Write(c + " ");

            }
            Console.Write("\n");


            while (!won && lives > 0)
            {
                Console.Write("Guess a letter:");

                input = Console.ReadLine().ToLower();
                if (input.Length > 1)
                {
                    lives--;
                    if (input.Equals(wordToguess))
                    {
                        Console.WriteLine(wordToguess);
                        won = true;
                    }

                }
                if (input.Length == 1)
                {


                    guess = input[0];

                    if (correctGuesses.Contains(guess))
                    {

                        Console.WriteLine($"You already tried '{guess}' and it was correct!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Lives left :{lives}");
                        Console.ResetColor();
                        continue;
                    }
                    else if (incorrectGuesses.ToString().Contains(guess))
                    {

                        Console.WriteLine("You already tried '{0}', an it was wrong!", guess);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Lives left :{lives}");
                        Console.ResetColor();
                        continue;
                    }
                    if (wordToguess.Contains(guess))
                    {
                        lives--;

                        correctGuesses.Append(guess);
                        for (int i = 0; i < wordToguess.Length; i++)
                        {
                            if (wordToguess[i] == guess)
                            {
                                correctGuesses[i] = wordToguess[i];

                            }

                        }
                        Writelivesleft(lives);
                        if (!correctGuesses.Contains('_'))
                            won = true;
                    }
                    else
                    {
                        incorrectGuesses.Append(guess);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Not in the Word:{incorrectGuesses}");
                        Console.ResetColor();
                        lives--;
                        Console.WriteLine($"Lives left :{lives}");
                    }

                    foreach (char c in correctGuesses)
                    {
                        Console.Write(c + " ");
                    }
                    Console.Write("\n");
                }
            }
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You won!");
            }

            else
                Console.WriteLine("You lose! it was '{0}'", wordToguess);
            Console.WriteLine("Press ENTER TO Exit...");
            Console.ReadLine();

        }
        static void Writelivesleft(int livesleft)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Lives left :{livesleft}");
            Console.ResetColor();
        }
    }
}





















