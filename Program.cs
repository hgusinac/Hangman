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

           StringBuilder displayToPlayer = new StringBuilder();//Se över (wordToGuess.Length)
           for (int i = 0; i < wordToguess.Length; i++)
             displayToPlayer.Append('_');
            
            



           string[] correctGuesses = new string [10];// Gör om till  Arrays 
           StringBuilder incorrectGuesses = new StringBuilder();// Gör om till String builder Arrays 
            
            int lives = 10; // ändra så att den inte räknar ner samma bokstav 
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;

            StringBuilder wrongWord  = new StringBuilder();

            // hur många liv som är kvar synligt !!
            Console.WriteLine(displayToPlayer);

           
            while (!won && lives > 0)
            {
                Console.WriteLine("Guess a letter:");
                
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
                   wrongWord.Append(guess);
                    Console.WriteLine($"No thats not in the word: \n{wrongWord }.");
                    Console.WriteLine($"Lives left :{lives}");
                    lives--;
                }
                Console.WriteLine(displayToPlayer.ToString());
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
    }
}




















