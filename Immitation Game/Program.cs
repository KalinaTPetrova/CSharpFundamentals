using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] cmdArgs = input.Split("|");
                string command = cmdArgs[0];
                switch (command)
                {
                    case "Move":
                        int n = int.Parse(cmdArgs[1]);
                        string replace = message.Substring(0,n);
                        message = message.Remove(0,n);
                        message = message.Insert(message.Length, replace);
                        
                        break;
                    case "Insert":
                        int index = int.Parse(cmdArgs[1]);
                        string value = cmdArgs[2];
                        if (index > 0)
                        { message = message.Insert(index, value); }
                        else { message = message.Insert(0, value); }
                        
                        break;
                    case "ChangeAll":
                        string substring = cmdArgs[1];
                        string replacement = cmdArgs[2];
                        message = message.Replace(substring, replacement);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }

    }
}
