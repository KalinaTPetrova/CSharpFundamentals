using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wins = 0;
            string input = Console.ReadLine();
            bool isEnergy = true;
            while(input!= "End of battle")
            {
                int distance = int.Parse(input);
                if (energy >= distance)
                {
                    energy -= distance;
                    wins++;
                }
                
                else if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    isEnergy = false;
                    break;
                }
                if (wins % 3 == 0)
                {
                    energy += wins;
                }

                input = Console.ReadLine();
            }
            if (isEnergy)
            { Console.WriteLine($"Won battles: {wins}. Energy left: {energy}"); }
        }
    }
}
