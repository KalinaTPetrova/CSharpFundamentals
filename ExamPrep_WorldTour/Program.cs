using System;

namespace ExamPrep_WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string stops = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] cmdArgs = input.Split(":");
                string command = cmdArgs[0];

                switch (command)
                {
                    case "Add Stop":
                        int index = int.Parse(cmdArgs[1]);
                        string newString = cmdArgs[2];
                        if (index>-1&&index<stops.Length)
                        {
                            stops=stops.Insert(index, newString);
                        }
                            Console.WriteLine(stops);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);
                        if (startIndex > -1 && endIndex < stops.Length)
                        {
                            stops = stops.Remove(startIndex,endIndex-startIndex+1) ;
                        }
                            Console.WriteLine(stops);
                        break;
                    case "Switch":
                        string old = cmdArgs[1];
                        string replace = cmdArgs[2];
                            if (stops.Contains(old))
                        {
                            stops = stops.Replace(old, replace);
                        }
                        Console.WriteLine(stops);
                        break;

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
