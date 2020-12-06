using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExam1
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());
            
            double maxbonus = 0.00;
            int maxattendance = 0;
            for (int i = 1; i <= studentsCount; i++)
            {
                int attendance = int.Parse(Console.ReadLine());

                double bonus = (1.0*attendance/lecturesCount) * (5 + initialBonus);
                if (bonus > maxbonus)
                {
                    maxbonus = bonus;
                    maxattendance = attendance;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxbonus)}.");
            Console.WriteLine($"The student has attended {maxattendance} lectures.");


            


        }
    }
}
