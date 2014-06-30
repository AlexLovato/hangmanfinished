using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            Welcome();
            Game();

        }
        static void Welcome()
        {
            //ask their name and welcome them
            Console.Write("TYPE YO NAME BOI! :");
            string name = Console.ReadLine();
            Console.WriteLine("welcome to the game, " + name + ".");
            Console.WriteLine("you will be guessing the letters in a word i've chosen.");
            Console.WriteLine("if you guess all the lettes before the man gets hanged, you win.");
        }
        static void Game()
        {
            //start random function
            Random random = new Random((int)DateTime.Now.Ticks);
           //call random word from string of words
            string[] words = new string[] { "computer", "frog", "chair", "hairnet", "fish", "taco", "bacon", "chimpanzee"};
            string wordToGuess = words[random.Next(0, words.Length-1)];
            string wordToGuessUppercase = wordToGuess.ToUpper();
         //make the ____ word
            StringBuilder blankword = new StringBuilder(words.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                blankword.Append('_');
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();
          
            
            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;
            //loop the game
            while (!won && lives > 0) 
            {
                Console.Write("Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];
                if (input == wordToGuessUppercase)
                {
                    Console.WriteLine("you win");
                    break;
                }
                else if (correctGuesses.Contains(guess)) 
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess)) 
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGuessUppercase.Contains(guess)) 
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++) 
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            blankword[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else 
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                    StringBuilder guessedLetters = new StringBuilder();
                    foreach (char charname in incorrectGuesses)
                    {
                        guessedLetters.Append(charname).Append(" ");
                        
                    }
                   Console.WriteLine("guessed letters : " + guessedLetters);
                    lives--;
                    Console.WriteLine("Lives Left : " + lives);
                }

                Console.WriteLine(blankword.ToString());
            }

            if (won)
                Console.WriteLine("You won!");
            else if (lives < 1)
            {
                Console.WriteLine("You lost! It was '{0}'", wordToGuess);
            }
            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
        