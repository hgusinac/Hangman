using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static string[] wordbank = { "haris", "gusinac", "ulf", "ammara", "huskvarna", };// random ord
        static void Main(string[] args)
        {
            Play();

        }
        static void Play()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            string wordToguess = wordbank[random.Next(0, wordbank.Length)]; // Random Ord att gissa
            string wordToGuessUppercase = wordToguess.ToUpper();
            StringBuilder displayToPlayer = new StringBuilder(wordToguess.Length);//Se över (wordToGuess.Length)
            for (int i = 0; i < wordToguess.Length; i++)
                displayToPlayer.Append('_');
            List<char> correctGuesses = new List<char>();// Gör om till  Arrays 
            List<char> incorrectGuesses = new List<char>();// Gör om till String builder Arrays 
            int lives = 10;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;

            // hur många liv som är kvar synligt !!



            while (!won && lives > 0)
            {
                Console.Write("Guess a letter:");
                input = Console.ReadLine().ToUpper();
                guess = input[0];
                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You already tried '{0}' and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You already tried '{0}', an it was wrong!", guess);
                    continue;
                }
                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);
                    for (int i = 0; i < wordToguess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToguess[i];
                            lettersRevealed++;
                        }

                    }
                    if (lettersRevealed == wordToGuessUppercase.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);
                    Console.WriteLine("No, there's no '{0}' in the word.", guess);
                    lives--;
                }
                Console.WriteLine(displayToPlayer.ToString());
            }
            if (won)
                Console.WriteLine("You won!");

            else
                Console.WriteLine("You lose! it was '{0}'", wordToguess);
            Console.WriteLine("Press ENTER TO Exit...");
            Console.ReadLine();

        }
    }
}




















