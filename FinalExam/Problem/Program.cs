using System;
using System.Text;

namespace Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string commands = Console.ReadLine();
            while (commands != "Complete")
            {
                string[] cmdArgs = commands.Split();
                string command = cmdArgs[0];
                              
                if(commands=="Make Upper")
                {
                    
                    for (int i = 0; i < email.Length; i++)
                    {
                        if (Char.IsLetter(email[i]))
                        {
                            char toReplace = Char.ToUpper(email[i]);
                            email= email.Replace(email[i], toReplace);
                        }
                    }
                    Console.WriteLine(email);
                }
                else if (commands=="Make Lower")
                {
                    
                    for (int i = 0; i < email.Length; i++)
                    {
                        if (Char.IsLetter(email[i]))
                        {
                            char toReplace = Char.ToLower(email[i]);
                            email = email.Replace(email[i], toReplace);
                        }
                    }
                    Console.WriteLine(email);
                }

                else if (command == "GetDomain")
                {
                    int count = int.Parse(cmdArgs[1]);
                    
                    string last = email.Substring(email.Length - count, count);
                    Console.WriteLine(last);
                   
                }

                else if(command == "GetUsername")
                {
                    if (!email.Contains('@'))
                    {
                        Console.WriteLine("The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {

                    int ind = email.IndexOf('@');
                    string newEmail = email.Substring(0, ind);
                    Console.WriteLine(newEmail);
                    }
                }
                else if(command == "Replace")
                {
                    char toBeReplaced = char.Parse(cmdArgs[1]);
                    string output = email.Replace(toBeReplaced, '-');
                    Console.WriteLine(output);
                }
                else if(command == "Encrypt")
                {
                    foreach (char item in email)
                    {
                        
                        Console.Write($"{(int)Convert.ToChar(item)} ");
                    }
                }
                commands = Console.ReadLine();
            }
        }
    }
}
