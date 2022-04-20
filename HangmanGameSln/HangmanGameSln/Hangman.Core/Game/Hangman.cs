using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
       // private string[] _randomWords = new string[] { "flood", "clock", "cinema", "permanent","absence","sweater","applied","policeman","long","flush"};
        private int[] _rendererMan = new int[6];
        private int[] _playerMan;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        private void GameMove()
         {

         }

        public void printMan(int lives)
        {

            if(lives == 0)
            {
                _renderer.Render(5, 5, 6);
            }
            else if (lives == 1) 
            {
                _renderer.Render(5, 5, 5);
            }
            else if(lives == 2)
            {
                _renderer.Render(5, 5, 4);
            }
            else if(lives == 3)
            {
                _renderer.Render(5, 5, 3);
            }
            else if(lives == 4)
            {
                _renderer.Render(5, 5, 2);
            }
            else if(lives == 5)
            {
                _renderer.Render(5, 5, 1);
            }
            else if(lives == 6)
            {
                _renderer.Render(5, 5, 0);
            }
        }

        public void Run()
        {
            //represent hangman's body
            _renderer.Render(5, 5, 6);

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

            //looping the game until the correct world is found
            while (true)
            {

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
                    if(nextGuess == unknownWord[g])
                    {
                        guess[g] = nextGuess;
                    }
                    
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
