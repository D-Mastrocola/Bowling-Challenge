using System;

namespace BowlingChallenge
{


    public class BowlingChallenge
    {
        public static int numOfFrames = 10;
        public static int totalPins = 10;
        public static int currentFrame = 1;
        public static string[] scoreList = new string[numOfFrames];

        public static int normalBowl(int currentPinCount)
        {
            Random rnd = new Random();
            int bowl = (int) Math.Floor(rnd.NextDouble() * (currentPinCount + 1));
            return bowl;
        }
        public static void displayScore()
        {
            string scoreStr = "";

            string topAndBot = "";
            int[] scoreIntArr = new int[numOfFrames];

            /*for(int i = 0; i < scoreList.Length i++)
            {
                if (scoreList[i] == "")
                {
                    break;
                }

                if (scoreList[i] == "X")
                {
                    if(scoreList[i] != "X" && scoreList[i].Length > 1)
                    {
                        if(scoreList[i] != "X")
                    }
                }
            }*/
            for (int i = 0; i < scoreList.Length; i++)
            {
                if (scoreList[i] != "")
                {
                    topAndBot += "___";
                    if(scoreList[i] == "X")
                    {
                        scoreStr += " " + scoreList[i] + "|";
                    } else
                    {
                        scoreStr += scoreList[i] + "|";
                    }

                }
            }
            scoreStr = "\n" + topAndBot + "\n" + scoreStr + "\n" + topAndBot;
            Console.WriteLine("==========================\n\n" + scoreStr + "\n\n==========================\n\n");
        }
        public static void play()
        {
            int score;
            int currentPinCount = totalPins;
            int bowlCount = 0; 
            while (currentFrame <= numOfFrames)
            {
                displayScore();
                //Get User Input
                Console.WriteLine("Frame: " + currentFrame);
                Console.WriteLine("Enter The Number Option" +
                        "\n1. Normal Bowl\n" +
                        "2. Cheater Bowl\n" +
                        "3. Loser Bowl\n");
                string userSelection = Console.ReadLine();


                //Bowl based on input
                int bowl;
                if (userSelection == "1")
                {
                    //Returns value from 0 - Current Pins
                    Console.WriteLine("Normal");
                    bowl = normalBowl(currentPinCount);
                }
                else if (userSelection == "2")
                {
                    //Best possible score
                    Console.WriteLine("Cheater");
                    bowl = currentPinCount;
                }
                else if (userSelection == "3")
                {
                    //Worst possible score
                    Console.WriteLine("Loser");
                    bowl = 0;
                }
                else
                {
                    //Get valid user input
                    Console.WriteLine("Invalid Option!!!!\n");
                    continue;
                }

                bowlCount++;

                Console.WriteLine(bowl);
                if(bowl == currentPinCount)
                {
                    if (bowlCount == 1)
                    {
                        //Strike
                        scoreList[currentFrame - 1] += "X";
                    }
                    else if (currentFrame == numOfFrames)
                    {
                        if (scoreList[currentFrame - 1][(bowlCount - 2)] == 'X')
                        {
                            //Strike
                            scoreList[currentFrame - 1] += "X";
                        }
                    }
                    else
                    {
                        //Spare
                        scoreList[currentFrame - 1] += "/";
                    }

                    //Unless its the 10th frame move to next frame
                    if (currentFrame != numOfFrames) bowlCount = 2;
                }else if(bowlCount == 2 && (bowl + Int32.Parse(scoreList[currentFrame - 1][0].ToString()) == totalPins)) { 
                        //Spare
                        scoreList[currentFrame - 1] += "/";
                    
                } else
                {
                    //Not a spare or strike
                    scoreList[currentFrame - 1] = scoreList[currentFrame - 1] + bowl.ToString();
                    Console.WriteLine("\n---" + scoreList[currentFrame - 1] + "---");
                    currentPinCount -= bowl;
                }
                
                if(bowlCount >= 2)
                {
                    if(currentFrame != numOfFrames || bowlCount > 2)
                    {
                        //If player has used all balls move to the next frame
                        currentFrame++;
                        bowlCount = 0;
                        currentPinCount = totalPins;
                    } else
                    {
                        //Check if player has thrown a spare or strike to get the third bowl
                        if (scoreList[currentFrame - 1][bowlCount-2] != 'X' && scoreList[currentFrame - 1][bowlCount - 2] != '/')
                        {
                            currentFrame++;
                            bowlCount = 0;
                            currentPinCount = totalPins;
                        }
                    }
                        
                }
            }
            displayScore();
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
                    Console.WriteLine("Starting Game...\n\n");
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
            for(int i = 0; i < scoreList.Length; i++)
            {
                scoreList[i] = "";
            }

            start();
        }
    }
}
