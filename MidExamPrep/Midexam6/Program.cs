using System;
using System.Collections.Generic;
using System.Linq;

namespace Midexam6
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> wagons = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            for (int i = 0; i < wagons.Count; i++)
            {
                int currentWagon = wagons[i];
                if (currentWagon < 4&&people>=4)
                {
                    int toAdd = 4 - currentWagon;
                    people -= toAdd;
                    currentWagon+=toAdd;
                }

            }
        }
    }
}
