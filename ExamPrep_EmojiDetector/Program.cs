using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ExamPrep_EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\:{2}|\*{2})([A-Z][a-z]{2,})\1";
            string digitPattern = @"\d";

            long coolT = 1;
            var digits = Regex.Matches(input, digitPattern);

            foreach (var item in digits)
            {
                coolT *= int.Parse(item.ToString());
            }

            var emojis = Regex.Matches(input, pattern);
            int count = emojis.Count;
            var coolEmojis = new List<string>();
            foreach (Match emoji in emojis)
            {
                string emo = emoji.Groups[2].Value;
                int coolness = 0;
                for (int i = 0; i < emo.Length; i++)
                {
                    coolness += emo[i];

                }
                if (coolness > coolT)
                {
                    coolEmojis.Add(emoji.ToString());
                }
            }
            Console.WriteLine($"Cool threshold: {coolT}");
            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
            foreach (var emo in coolEmojis)
            {
                Console.WriteLine(emo);
            }

        }
    }
}
