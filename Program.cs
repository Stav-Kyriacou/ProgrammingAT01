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

            while (keepRolling)
            {
                int currentRoll = RollDice(6);
                diceRolls.Add(currentRoll);
                Console.WriteLine("Result: {0}", currentRoll);
                Console.Write("Type \'y\' to roll again or any other key to stop: ");

                string input = Console.ReadLine();
                Console.WriteLine("------------------------");

                if (input != "y")
                {
                    keepRolling = false;
                }
            }
            Console.Write("You rolled the dice {0} time(s). How many of the rolls do you want info for: ", diceRolls.Count);

            int limit = int.Parse(Console.ReadLine());
            DisplayRollInfo(diceRolls, limit);
        }
        public static int RollDice(int sides)
        {
            Console.WriteLine("Rolling {0} sided dice", sides);
            Random dice = new Random();
            return dice.Next(1, sides + 1);
        }
        public static void DisplayRollInfo(List<int> rolls, int limit)
        {
            Console.Write("The rolls were: ");
            for (int i = 0; i < limit; i++)
            {
                Console.Write(rolls[i]);

                if (i < limit - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("The total number rolled was: {0}", CalcSum(rolls, limit));
            Console.WriteLine("The average number rolled was: {0}", CalcAverage(rolls, limit));
        }
        public static int CalcSum(List<int> nums, int limit)
        {
            int sum = 0;

            for (int i = 0; i < limit; i++)
            {
                sum += nums[i];
            }

            return sum;
        }
        public static double CalcAverage(List<int> nums, int limit)
        {
            double sum = 0;

            for (int i = 0; i < limit; i++)
            {
                sum += nums[i];
            }

            return Math.Round((sum / limit), 2);
        }
    }
}
