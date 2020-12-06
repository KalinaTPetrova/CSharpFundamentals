using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
namespace CsharpFundamentalsExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] cmds = input.Split(":|:");
                string command = cmds[0];

                switch (command)
                {
                    case "InsertSpace":
                        int index = int.Parse(cmds[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string substring = cmds[1];
                        if (!message.Contains(substring))
                        {
                            Console.WriteLine("error");
                        }
                        else
                        {
                            int ind = message.IndexOf(substring);

                            string reversed = Reverse(substring);

                            message = message.Remove(ind, substring.Length);
                            message = message.Insert(message.Length, reversed);
                            Console.WriteLine(message);
                        }
                        break;
                    case "ChangeAll":
                        string sub = cmds[1];
                        string repl = cmds[2];
                        message = message.Replace(sub, repl);
                        Console.WriteLine(message);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
