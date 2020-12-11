using System;

namespace ExamPrep_ActivationKey
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] cmdArgs = command.Split(">>>");

                if (cmdArgs[0] == "Contains")
                {
                    if (activationKey.Contains(cmdArgs[1]))
                    {
                        Console.WriteLine($"{activationKey} contains {cmdArgs[1]}");

                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (cmdArgs[0] == "Flip")
                
                {
                    int start = int.Parse(cmdArgs[2]);
                    int end = int.Parse(cmdArgs[3]);

                    if (cmdArgs[1] == "Upper")
                    {
                        string sub= activationKey.Substring(start, end - start).ToUpper();
                        activationKey = activationKey.Remove(start, end - start);
                        activationKey = activationKey.Insert(start, sub);
                    }
                    else if (cmdArgs[1] == "Lower")
                    {
                        string sub = activationKey.Substring(start, end - start).ToLower();
                        activationKey = activationKey.Remove(start, end - start);
                        activationKey = activationKey.Insert(start, sub);

                    }
                    Console.WriteLine(activationKey);
                }
                else if (cmdArgs[0] == "Slice")
                {
                    int ind1 = int.Parse(cmdArgs[1]);
                    int ind2 = int.Parse(cmdArgs[2]);

                    activationKey = activationKey.Remove(ind1, ind2 - ind1);
                    Console.WriteLine(activationKey);

                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {activationKey}");

        }
    }
}
