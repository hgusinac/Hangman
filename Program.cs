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
            //lägg till en meny som loppar  med att köra spelet igen.
            // bygga på ordbanken 

            string[] wordbank = { "haris", "gusinac", "ulf", "ammara", "huskvarna", "games", "båt", "is" };// random ord

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




            while (!won && lives > 0)// om man gissar på hela ordet 
            {
                Status(lives, incorrectGuesses, correctGuesses);
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
                if (input.Length == 1)// om man gissar på en bokstav
                {


                    guess = input[0];

                    if (correctGuesses.Contains(guess))
                    {

                        Console.WriteLine($"You already tried '{guess}' and it was correct!");

                    }
                    else if (incorrectGuesses.ToString().Contains(guess))
                    {

                        Console.WriteLine("You already tried '{0}', an it was wrong!", guess);

                    }
                    else if (wordToguess.Contains(guess))
                    {
                        lives--;

                        correctGuesses.Append(guess);
                        for (int i = 0; i < wordToguess.Length; i++)//när man gissar rätt händer detta.
                        {

                            if (wordToguess[i] == guess)

                            {
                                correctGuesses[i] = wordToguess[i];



                            }

                        }

                        if (!correctGuesses.Contains('_'))
                            won = true;
                    }
                    else
                    {
                        incorrectGuesses.Append(guess);
                        lives--;


                    }

                    
                }
            }
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(wordToguess);
                Console.WriteLine("You won!");
            }

            else
                Console.WriteLine("You lose! it was '{0}'", wordToguess);
            Console.WriteLine("Press ENTER TO Exit...");
            Console.ReadLine();

        }
        static void Status(int livesleft, StringBuilder incorrectGuesses, char[] correctGuesses)
        {
            foreach (char c in correctGuesses)
            {
                if (c != '_')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(c + " ");

            }
            Console.Write("\n");

            if (!incorrectGuesses.Equals(""))
            {
                Console.WriteLine($"Not in the Word:{incorrectGuesses}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Lives left :{livesleft}");
            Console.WriteLine(
                );
            Console.ResetColor();

        }
    }
}





















