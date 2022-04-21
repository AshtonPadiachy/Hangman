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
            string guessLetter = string.Empty;

            //outputting the word's length as dashes
            for (int w = 0; w < unknownWord.Length; w++)
            {
                _guess[w] = '-';
            }

            //looping the game until you lose
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
                {
                    for (var g = 0; g < unknownWord.Length; g++)
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
                //state when the player won
                guessLetter = new string(_guess);

                if (guessLetter == unknownWord)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine("YAY! YOU SURVIVED! ;)");
                }


            }

            //state when the player lost
            if(guessLetter != unknownWord)
            {
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("SORRY! YOU HAVE DIED! :-(");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The word was: "+ unknownWord);

            }

        }

    }
}
