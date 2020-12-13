using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> likes = new Dictionary<string, int>();
            Dictionary<string, int> comments = new Dictionary<string, int>();

            while (input != "Log out")
            {
                string[] tokens = input.Split(": ");
                string command = tokens[0];
                string user = tokens[1];

                if (command == "New follower")
                {
                    if (!likes.ContainsKey(user))
                    {
                        likes.Add(user, 0);
                    }
                    if (!comments.ContainsKey(user))
                    {
                        comments.Add(user, 0);

                    }
                }
                else if (command == "Like")
                {
                    int likeCount = int.Parse(tokens[2]);
                    if (!likes.ContainsKey(user))
                    {
                        likes.Add(user, likeCount);
                        
                    }
                    else
                    {

                    likes[user] += likeCount;
                    }
                }
                else if (command == "Comment")
                {

                    if (!comments.ContainsKey(user))
                    {
                        comments.Add(user, 1);
                        
                    }
                    else
                    {

                    comments[user] += 1;
                    }
                }
                
                else if (command == "Blocked")
                {
                    if (!likes.ContainsKey(user) && !comments.ContainsKey(user))
                    {
                        Console.WriteLine($"{user} doesn't exist.");
                    }
                    else
                    {
                        likes.Remove(user);
                        comments.Remove(user);
                    }

                }
                input = Console.ReadLine();

                
            }
            foreach (var item in likes)
            {
                if (!comments.ContainsKey(item.Key))
                {
                    comments.Add(item.Key, 0);
                }
            }
            foreach (var item in comments)
            {
                if (!likes.ContainsKey(item.Key))
                {
                    likes.Add(item.Key, 0);
                }
            }
            Console.WriteLine($"{likes.Count} followers");
            foreach (var item in likes.OrderByDescending(x => x.Value + comments[x.Key]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value + comments[item.Key]}");
            }
        }
    }
}