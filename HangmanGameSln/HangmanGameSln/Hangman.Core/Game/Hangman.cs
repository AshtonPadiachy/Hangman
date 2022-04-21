using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        //Give 20 words to guess from
        private string[] _listWords = new string[20] { "flood", "clock", "cinema", "permanent", "absence",
          "sweater","applied", "policeman", "long", "flush","video","bolt","voucher", "belly",
          "contradiction", "mathematics","projection","concern", "orientation","multiverse"};
        private string unknownWord;
        private GallowsRenderer _renderer;
        private int _lives = 6;
        private char[] _guess;


        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
            //select a random word in the array
            Random randomWord = new Random();
            var index = randomWord.Next(0, 19);
            unknownWord = _listWords[index];
            _guess = unknownWord.ToCharArray();
        }


        public void Run()
        {
            //outputting the random word's length as underscores
            for (int w = 0; w < unknownWord.Length; w++)
            {
                _guess[w] = '-';
            }

            //looping the game until you die
           while(_lives > 0 && _lives <= 6)
            {

                //represent hangman's body
                _renderer.Render(5, 5, _lives);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(_guess);

                //Console.WriteLine("--------------");
                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                var nextGuess = char.Parse(Console.ReadLine());

                bool correctWord = false;

                for (int g = 0; g < unknownWord.Length; g++)
                {
                    if (nextGuess == unknownWord[g])
                    {
                        _guess[g] = nextGuess;
                        correctWord = true;
                    }

                }
                if (!correctWord)
                {
                    _lives--;
                   _renderer.Render(5, 5, _lives);
                }
                

            }

            //state whether the player won or lost

            string guessLetter = new string(_guess);

            if(guessLetter == unknownWord)
            {
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("YOU SURVIVED!");
            }
            else
            {
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("YOU HAVE DIED!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The word was: "+ unknownWord);

            }

        }

    }
}
