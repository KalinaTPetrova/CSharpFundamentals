using System;

namespace ExamPrep_PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string password = "";
            string commands = Console.ReadLine();
            while (commands != "Done")
            {
                string[] cmdArgs = commands.Split();
                string command = cmdArgs[0];

                switch (command)
                {
                    case "TakeOdd":
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (i % 2 == 1)
                            {
                                password += input[i];
                                
                            }
                        }
                                Console.WriteLine(password);
                        break;
                    case "Cut":
                        break;
                    case "Substitute":
                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine();
            }
        }
    }
}
