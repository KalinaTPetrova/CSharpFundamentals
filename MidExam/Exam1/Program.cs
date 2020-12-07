using System;

namespace Exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());
            double currentExperience = 0;
            bool isEnoughExperience = false;
            for (int i = 1; i <=battlesCount; i++)
            {
                double experiencePerbattle = double.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    experiencePerbattle *= 1.15;
                }
                if (i % 5 == 0)
                {
                    experiencePerbattle *= 0.90;
                }
                if (i % 15 == 0)
                {
                    experiencePerbattle *= 1.05;
                }
                currentExperience += experiencePerbattle;
                if (currentExperience >= neededExperience)
                {
                    battlesCount = i;
                    isEnoughExperience = true;
                    break;
                }
                
            }
            if (isEnoughExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(neededExperience - currentExperience):f2} more needed.");
            }
        }
    }
}
