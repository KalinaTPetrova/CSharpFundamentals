using System;
using System.Text;

namespace ExamPrep_PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            
            string commands = Console.ReadLine();
            while (commands != "Done")
            {
                string[] cmdArgs = commands.Split();
                string command = cmdArgs[0];

                switch (command)
                {
                    case "TakeOdd":
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                sb.Append(password[i]);

                            }
                        }
                        password = sb.ToString();
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(cmdArgs[1]);
                        int length = int.Parse (cmdArgs[2]);
                        password = password.Remove(index, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substring = cmdArgs[1];
                        string substitute = cmdArgs[2];
                        if (password.Contains(substring))
                        { password = password.Replace(substring, substitute); 
                            Console.WriteLine(password); }
                        else { Console.WriteLine("Nothing to replace!"); }
                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}

