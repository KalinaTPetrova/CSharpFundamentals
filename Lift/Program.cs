using System;
using System.Collections.Generic;
using System.Linq;

namespace Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> waggons = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isEmpty = false;
            


            for (int i = 0; i < waggons.Count; i++)
            {

                while (waggons[i] < 4)
                {

                    
                    if (people == 0)
                    {
                        isEmpty = true;
                        break;
                    }

                    
                    waggons[i]++;
                    people--;


                }             



            }


            if (isEmpty)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", waggons));
            }
            if (people>0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", waggons));

            }
            if (!isEmpty && people == 0)
            { Console.WriteLine(string.Join(" ", waggons)); }

        }
    }
}
