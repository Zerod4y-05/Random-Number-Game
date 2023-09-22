using System;
using System.Media;

namespace RandomNumberGenerator
{
    internal class RandomGame
    {
        private readonly string asciiArt = @"
 _   _                 _                  _____                      
| \ | |               | |                / ____|                     
|  \| |_   _ _ __ ___ | |__   ___ _ __  | |  __  __ _ _ __ ___   ___ 
| . ` | | | | '_ ` _ \| '_ \ / _ \ '__| | | |_ |/ _` | '_ ` _ \ / _ \
| |\  | |_| | | | | | | |_) |  __/ |    | |__| | (_| | | | | | |  __/
|_| \_|\__,_|_| |_| |_|_.__/ \___|_|     \_____|\__,_|_| |_| |_|\___|
                                                                     
                                                                     
Welcome to my Random Number Game! 
Guess a number, and I'll tell you if my number is higher or lower.
";

        private int score;

        public void Play()
        {
            PlayMusic("RaceForSpace.wav");

            bool playAgain = true;
            while (playAgain)
            {
                Console.Clear();
                score = 0;
                bool guessedCorrectly = PlayGame();
                if (guessedCorrectly)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Play again? (press y to continue or any key to exit)");
                    Console.ForegroundColor = ConsoleColor.White;
                    playAgain = Console.ReadLine() == "y";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, you lost! Play again? (press y to continue or any key to exit)");
                    Console.ForegroundColor = ConsoleColor.White;
                    playAgain = Console.ReadLine() == "y";
                }
            }
        }

        private bool PlayGame()
        {
            Random random = new Random();
            int value = random.Next(0, 100);
            int tries = 0;
            int guess = 0;
            
            Console.WriteLine(asciiArt);

            while (guess != value)
            {
                
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Guess a number between 1 and 100");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tries:"+ tries);
               
                try
                {
                    guess = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Not a valid input, try a number between 1 and 100");
                    continue;
                }

                if (guess > value)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Guess lower");
                }
                else if (guess < value)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Guess higher");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Bravo, you did it! Now get yourself a cookie and go outside.");
                    int frequency = 2000;
                    int duration = 800;
                    Console.Beep(frequency, duration);
                    score++;
                    Console.WriteLine("Score: " + score);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Tries: " + tries);
                }

                tries++;
            }

            return true;
        }

        private static void PlayMusic(string filepath)
        {
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filepath;
            musicPlayer.Play();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            RandomGame randomGame = new RandomGame();
            randomGame.Play();
        }
    }
}
