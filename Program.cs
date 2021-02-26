using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static string[] wordbank = { "haris", "gusinac", "ulf", "ammara", "huskvarna" };// random ord
        static void Main(string[] args)
        {
            Play();

        }
        static void Play()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            string wordToguess = wordbank[random.Next(0, wordbank.Length)]; // Random Ord att gissa
            

            /*StringBuilder displayToPlayer = new StringBuilder();//Se över (wordToGuess.Length)
            for (int i = 0; i < wordToguess.Length; i++)
                displayToPlayer.Append('_');*/


            

            char[] correctGuesses = new char[10];// Gör om till  Arrays 

            StringBuilder incorrectGuesses = new StringBuilder();// fel gissningar

            // List<char> incorrectGuesses = new List<char>();// Gör om till String builder Arrays 

            int lives = 9;
            bool won = false;
            
            string input;
            char guess;



            
            Console.WriteLine(displayToPlayer);


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
                    
                    if (displayToPlayer.ToString().Contains(guess))
                    {
                        
                        Console.WriteLine($"You already tried '{guess}' and it was correct!");
                        continue;
                    }
                    else if (incorrectGuesses.ToString().Contains(guess))
                    {

                        Console.WriteLine("You already tried '{0}', an it was wrong!", guess);
                        continue;
                    }
                    if (wordToguess.Contains(guess))
                    {
                        correctGuesses.Append(guess);
                        for (int i = 0; i < wordToguess.Length; i++)
                        {
                            if (wordToguess[i] == guess)
                            {
                                displayToPlayer[i] = wordToguess[i];
                               
                            }

                        }
                        if (!displayToPlayer.ToString().Contains('_'))
                            won = true;
                    }
                    else
                    {
                        incorrectGuesses.Append(guess);
                        Console.WriteLine($"No, its not in the word\n :{incorrectGuesses}");
                        Console.WriteLine($"Lives left :{lives}");
                        lives--;
                    }
                    Console.WriteLine(displayToPlayer.ToString());
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
    }
}





















