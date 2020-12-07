using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string itemType = Console.ReadLine();
            string typePriceratings = Console.ReadLine();
            int resultRight = 0;
            int resultLeft = 0;
            for (int i = entryPoint + 1; i <= priceRatings.Length - 1; i++)
            {
                switch (itemType)
                {
                    case "cheap":
                        if (priceRatings[i] < priceRatings[entryPoint])
                        {
                            switch (typePriceratings)
                            {
                                case "positive":
                                    if (priceRatings[i] > 0)
                                    {
                                        resultRight += priceRatings[i];
                                    }
                                    break;
                                case "negative":
                                    if (priceRatings[i] < 0)
                                    {
                                        resultRight += priceRatings[i];
                                    }
                                    break;
                                case "all":
                                    resultRight += priceRatings[i];
                                    break;
                            }
                        }
                        break;
                    case "expensive":
                        if (priceRatings[i] >= priceRatings[entryPoint])
                        {
                            switch (typePriceratings)
                            {
                                case "positive":
                                    if (priceRatings[i] > 0)
                                    {
                                        resultRight += priceRatings[i];
                                    }
                                    break;
                                case "negative":
                                    if (priceRatings[i] < 0)
                                    {
                                        resultRight += priceRatings[i];
                                    }
                                    break;
                                case "all":
                                    resultRight += priceRatings[i];
                                    break;
                            }
                        }
                        break;
                }
            }
            for (int j = 0; j < entryPoint; j++)
            {
                switch (itemType)
                {
                    case "cheap":
                        if (priceRatings[j] < priceRatings[entryPoint])
                        {
                            switch (typePriceratings)
                            {
                                case "positive":
                                    if (priceRatings[j] > 0)
                                    {
                                        resultLeft += priceRatings[j];
                                    }
                                    break;
                                case "negative":
                                    if (priceRatings[j] < 0)
                                    {
                                        resultLeft += priceRatings[j];
                                    }
                                    break;
                                case "all":
                                    resultLeft += priceRatings[j];
                                    break;
                            }
                        }
                        break;
                    case "expensive":
                        if (priceRatings[j] >= priceRatings[entryPoint])
                        {
                            switch (typePriceratings)
                            {
                                case "positive":
                                    if (priceRatings[j] > 0)
                                    {
                                        resultLeft += priceRatings[j];
                                    }
                                    break;
                                case "negative":
                                    if (priceRatings[j] < 0)
                                    {
                                        resultLeft += priceRatings[j];
                                    }
                                    break;
                                case "all":
                                    resultLeft += priceRatings[j];
                                    break;
                            }
                        }
                        break;
                }
            }
            if (resultLeft >= resultRight)
            {
                Console.WriteLine($"Left - {resultLeft}");
            }
            else 
            {
                Console.WriteLine($"Right - {resultRight}");
            }
            
        }
    }
}
