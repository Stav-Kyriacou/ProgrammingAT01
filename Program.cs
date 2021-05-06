using System;
using System.Collections.Generic;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> diceRolls = new List<int>();
            bool keepRolling = true;
            int numSides = 0;
            int numDice = 0;

            Console.WriteLine("----Dice Roll Program----");

            //ask for number of dice and sides
            Console.Write("Sides on dice: ");
            numSides = int.Parse(Console.ReadLine());

            Console.Write("Number of dice: ");
            numDice = int.Parse(Console.ReadLine());

            while (keepRolling)
            {
                //roll dice method returns a list of rolls, pass it the numSides and numDice so it returns the rolls
                //add each roll from the method to a list to track everything
                foreach (int roll in RollDice(numSides, numDice))
                {
                    diceRolls.Add(roll);
                }

                //ask the user if they want to keep rolling
                Console.WriteLine();
                Console.Write("Type \'y\' to roll again or any other key to stop: ");

                string input = Console.ReadLine();
                Console.WriteLine("------------------------");

                //if the input if anything other than y, stop asking for rolls
                if (input != "y")
                {
                    keepRolling = false;
                }
            }

            //ask for how many rolls of the total they want information for
            Console.Write("You rolled the dice {0} time(s). How many of the rolls do you want info for: ", diceRolls.Count);

            int limit = int.Parse(Console.ReadLine());
            DisplayRollInfo(diceRolls, limit);
        }
        public static List<int> RollDice(int numSides, int numRolls)
        {
            //method takes the numSides of the dice and how many times to roll it
            List<int> rolls = new List<int>();

            Console.WriteLine("Rolling {0} sided dice {1} time(s)", numSides, numRolls);
            Console.Write("Rolls: ");

            //rolls the dice the specified number of times and prints to console what the rolls were
            for (int i = 0; i < numRolls; i++)
            {   
                Random dice = new Random();
                int currentRoll = dice.Next(1, numSides + 1);
                rolls.Add(currentRoll);

                Console.Write(currentRoll);

                if (i < numRolls - 1)
                {
                    Console.Write(", ");
                }
            }
            return rolls;
        }
        public static void DisplayRollInfo(List<int> rolls, int limit)
        {
            //displays what all the rolls were up to the number of times specified by user input
            Console.Write("The rolls were: ");
            for (int i = 0; i < limit; i++)
            {
                Console.Write(rolls[i]);

                if (i < limit - 1)
                {
                    Console.Write(", ");
                }
            }
            //use the sam rolls and limit values to execute the CalcSum and CalcAverage methods
            Console.WriteLine();
            Console.WriteLine("The total number rolled was: {0}", CalcSum(rolls, limit));
            Console.WriteLine("The average number rolled was: {0}", CalcAverage(rolls, limit));
        }
        public static int CalcSum(List<int> nums, int limit)
        {
            //loops through the nums in the list a specified number of times and returns the sum
            int sum = 0;

            for (int i = 0; i < limit; i++)
            {
                sum += nums[i];
            }

            return sum;
        }
        public static double CalcAverage(List<int> nums, int limit)
        {
            //loops through the nums in the list a specified number of times. divides the sum by the limit
            //to return the average rounded to 2 decimal places
            double sum = 0;

            for (int i = 0; i < limit; i++)
            {
                sum += nums[i];
            }

            return Math.Round((sum / limit), 2);
        }
    }
}
