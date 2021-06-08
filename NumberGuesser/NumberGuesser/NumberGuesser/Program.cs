using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            static void MainGame()
            {
                Console.Clear();
                Random rnd = new Random();
                int winnum = rnd.Next(0, 100);
                int maxGuesses = 5;
                int currentGuess = 0;

                bool win = false;
                bool lose = false;

                Console.WriteLine("Guess a number between 0 and 100: ");
                do
                {
                    if (currentGuess >= maxGuesses)
                    {
                        loser(winnum);
                        //lose = true;
                    }
                    else
                    {
                        string s = Console.ReadLine();

                        int ans = int.Parse(s);

                        if (ans > winnum)
                        {
                            Console.WriteLine("Too High! Try Again! \n");
                        }
                        else if (ans < winnum)
                        {
                            Console.WriteLine("Too Low! Try Again! \n");
                        }
                        else if (ans == winnum)
                        {
                            winner(winnum);
                            //win = true;
                        }
                    }
                    currentGuess++;
                } while (win == false && lose == false);
            }
            static void winner(int num)
            {
                Console.WriteLine($"You win! The answer was {num}");
                Console.WriteLine("Play Again? (y/n)");
                string ans = Console.ReadLine();
                if (ans == "y")
                {
                    MainGame();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            static void loser(int num)
            {
                Console.WriteLine($"Sorry, you lose! The number was {num}");
                Console.WriteLine("Play Again? (y/n)");
                string ans = Console.ReadLine();
                if (ans == "y")
                {
                    MainGame();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            MainGame();
        }
    }
}
