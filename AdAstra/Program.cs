using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(\#|\|)([A-Z"" ""a-z]+)\1([\d]{2}\/[\d]{2}\/[\d]{2})\1(\d+)\1";
            var matches = Regex.Matches(text, pattern);
            var callories = 0;
            
            foreach (Match item in matches)
            {
                callories += int.Parse(item.Groups[4].Value);
                
            }
            int days = callories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match item in matches)
            {
                string name = item.Groups[2].Value;
                string date = item.Groups[3].Value;
                int calories = int.Parse(item.Groups[4].Value);
                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
