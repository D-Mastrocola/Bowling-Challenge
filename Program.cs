using System;
namespace BowlingChallenge
{
    public class BowlingChallenge
    {
        public static void play()
        {
            Console.WriteLine("play");
        }
        public static void viewHighScores()
        {
            Console.WriteLine("===================\nHighscores: \n\n1.Dominic: 200\n2.Paul: 199\n3.Jake: 100\n===================\n");
        }
        public static void start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter The Number Option" +
                    "\n1. Play\n" +
                    "2. View Highscores\n" +
                    "3. Exit\n");
                string userSelection = Console.ReadLine();
                if (userSelection == "1")
                {
                    play();
                }
                else if (userSelection == "2")
                {
                    viewHighScores();
                }
                else if (userSelection == "3")
                {
                    exit = true;
                    Console.WriteLine("\nExit\n");
                }
                else
                {
                    Console.WriteLine("Invalid Option!!!!\n");
                }
            }
        }
        public static void Main(string[] args)
        {
            int numOfFrames = 10;
            int numOfPins = 10;
            int currentFrame = 1;

            //Create score list with size of the amount of frames
            string[] scoreList = new string[numOfFrames];

            start();
        }
    }
}
