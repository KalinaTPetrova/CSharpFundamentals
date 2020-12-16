using System;
using System.Collections.Generic;
using System.Linq;

namespace Pianist_Alternative
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Pieces> pieces = new Dictionary<string, Pieces>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] initialPieces = input.Split("|");

                Pieces newPiece = new Pieces(initialPieces[0], initialPieces[1], initialPieces[2]);
                pieces.Add(initialPieces[0], newPiece);

            }
            string commands = Console.ReadLine();
            while (commands != "Stop")
            {
                string[] cmdArgs = commands.Split("|");

                if (cmdArgs[0] == "Add")
                {
                    Pieces currentPiece = new Pieces(cmdArgs[1], cmdArgs[2], cmdArgs[3]);
                    if (!pieces.ContainsKey(cmdArgs[1]))
                    {
                        
                        pieces.Add(cmdArgs[1],currentPiece);
                        Console.WriteLine($"{cmdArgs[1]} by {cmdArgs[2]} in {cmdArgs[3]} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{cmdArgs[1]} is already in the collection!");
                    }
                }
                else if (cmdArgs[0] == "Remove")
                {
                    if (!pieces.ContainsKey(cmdArgs[1]))
                    {

                        Console.WriteLine($"Invalid operation! {cmdArgs[1]} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(cmdArgs[1]);
                        Console.WriteLine($"Successfully removed {cmdArgs[1]}!");
                    }
                }
                else if (cmdArgs[0] == "ChangeKey")
                {
                    if (!pieces.ContainsKey(cmdArgs[1]))
                    {

                        Console.WriteLine($"Invalid operation! {cmdArgs[1]} does not exist in the collection.");
                    }
                    else
                    {
                        pieces[cmdArgs[1]].ChangeKey(cmdArgs[2]);
                        Console.WriteLine($"Changed the key of {cmdArgs[1]} to {cmdArgs[2]}!");
                    }
                }
                commands = Console.ReadLine();
            }

            foreach (var item in pieces.OrderBy(x=>x.Value.Piece).ThenBy(x=>x.Value.Composer))
            {
                Console.WriteLine($"{item.Value.Piece} -> Composer: {item.Value.Composer}, Key: {item.Value.Key}");

            }
        }

        public class Pieces
        {
            public Pieces(string piece, string composer, string key)
            {
                Piece = piece;
                Composer = composer;
                Key = key;

            }
            public string Piece { get; set; }
            public string Composer { get; set; }
            public string Key { get; set; }

            public void ChangeKey(string key)
            {
                Key = key;
            }

            
        }
    }
}
