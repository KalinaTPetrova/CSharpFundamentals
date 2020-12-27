using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();
            int count = 0;
            List<int> shot = new List<int>();
            while (input != "End")
            {
                int index = int.Parse(input);
                if (index >= 0 && index < targets.Count)
                {
                    if (!shot.Contains(index))
                    {
                        int currentTarget = targets[index];
                        targets[index] = -1;
                        count++;
                        shot.Add(index);
                        for (int i = 0; i < targets.Count; i++)
                        {
                            if (i != index && !shot.Contains(i))

                            {

                                if (targets[i] > currentTarget)
                                {

                                    targets[i] -= currentTarget;
                                }
                                else if (targets[i] <= currentTarget)
                                {
                                    targets[i] += currentTarget;
                                }

                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", targets)} ");
        }
    }
}
