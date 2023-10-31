

using GuessingGame.Generators;

namespace GuessingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nGuess the number!! Win the price!!");
            int betPrice = GetInput("Please enter proper bet amount :", 0, 0);
            int level = GetInput("Choose Difficulty Level  | 1 : Easy | 2: Medium | 3 : Hard  ", 0, 3);
            int endRange = 0;
            string range = "";
            if (level == 1)
            {
                endRange = 5;
                range = "1-5";
            }
            else if (level == 2)
            {
                range = "1-10";
                endRange = 10;
            }
            else if (level == 3)
            {
                range = "1-20";
                endRange = 20;
            }
            int guessedNumber = GetInput("Guess the number between " + range, 0, endRange);
            bool result = CheckGuessedNumber(guessedNumber, endRange, betPrice);
            if (result)
            {
                Console.WriteLine("\nWooow! Congratulations! You have won Rs." + (betPrice * endRange));
            }
            else
            {
                Console.WriteLine($"\nOhh Sorry! You have guessed wrong number ({guessedNumber})");
            }

        }

        public static bool CheckGuessedNumber(int guessedNumber, int endRange, int betPrice)
        {
            INumberGenerator rng = new RandomNumberGenerator();
            int generatedNo = rng.Generate(endRange);
            if (generatedNo == guessedNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int GetInput(string message, int startRange, int endRange)
        {
            Console.WriteLine("\n" + message);
            var input = Console.ReadLine();
            int returnInput;
            while (!int.TryParse(input, out returnInput) || returnInput < startRange || (endRange > 0 && returnInput > endRange))
            {
                Console.WriteLine("\n" + message);
                input = Console.ReadLine();
            }
            return returnInput;
        }
    }

    public sealed class GameResultCalculator
    {
        private readonly INumberGenerator _numberGenerator;

        public GameResultCalculator(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public bool CheckGuessedNumber(int guessedNumber, int endRange, int betPrice)
        {
            int generatedNo = _numberGenerator.Generate(endRange);
            if (generatedNo == guessedNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}