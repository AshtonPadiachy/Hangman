using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private int _counter;
        private GallowsRenderer _renderer;


        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }


        public void Run()
        {
            //Give 20 words to guess from
            string[] listWords = new string[20] { "flood", "clock", "cinema", "permanent", "absence",
            "sweater","applied", "policeman", "long", "flush","video","bolt","voucher", "belly", 
             "contradiction", "mathematics","projection","concern", "orientation","multiverse"};

            //select a random word in the array
            Random randomWord = new Random();
            var index = randomWord.Next(0, 19);
            string unknownWord = listWords[index];
            char[] guess = new char[unknownWord.Length];

            //outputting the random word's length as underscores
            for (int w = 0; w < unknownWord.Length; w++)
            {
                guess[w] = '_';
            }

            //looping the game until the correct word is found
            while (true)
            {
                //represent hangman's body
                _renderer.Render(5, 5, 6);


                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(guess);

                

                //Console.WriteLine("--------------");
                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                var nextGuess = char.Parse(Console.ReadLine());
                for (int g = 0; g < unknownWord.Length; g++)
                {
                    if (nextGuess == unknownWord[g])
                    {
                        guess[g] = nextGuess;
                    }
                    //work on this part and renderer!!!!
                   // else if(nextGuess != guess[g])
                   // {
                     //   Console.WriteLine("Wrong guess! Please try again");
                    
                   // }


                }
                /* Console.SetCursorPosition(0, 13);
                  Console.ForegroundColor = ConsoleColor.Blue;
                  Console.Write("Your current guess: ");
                  Console.WriteLine("--------------");
                  Console.SetCursorPosition(0, 15);
                  Console.ForegroundColor = ConsoleColor.Green;

                  Console.Write("What is your next guess: ");
                  var nextGuess = Console.ReadLine();
                 */

            }
            

            /* 
             //state whether the player won or lost
              if (survived)
              {
                  Console.WriteLine("YOU SURVIVED!");
              }
              else
              {
                  Console.WriteLine("YOU DIED!");
              }*/

        }

    }
}
