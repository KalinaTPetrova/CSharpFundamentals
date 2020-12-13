using System;
using System.Text.RegularExpressions;

namespace PRoblem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(U\$)([A-Z][a-z]{2,})\1(P\@\$)([A-Za-z]{5,}[\d]+)\3";
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match valid = Regex.Match(input, pattern);
                
                if (valid.Success)
                {
                    Console.WriteLine("Registration was successful");
                    count++;
                    string user = valid.Groups[2].Value;
                    string pass = valid.Groups[4].Value;
                    Console.WriteLine($"Username: {user}, Password: {pass}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {count}");
        }
    }
}
