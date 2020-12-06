using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrep_NeedForSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCars = int.Parse(Console.ReadLine());
            var m = new Dictionary<string, int>();
            var f = new Dictionary<string, int>();


            for (int i = 0; i < numCars; i++)
            {
                string[] car = Console.ReadLine().Split("|");
                string carName = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);

                m[carName] = mileage;
                f[carName] = fuel;

            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] cmdArgs = input.Split(" : ");
                string command = cmdArgs[0];
                string currentCar = cmdArgs[1];
                switch (command)
                {
                    case "Drive":
                        
                        int distance = int.Parse(cmdArgs[2]);
                        int gas = int.Parse(cmdArgs[3]);
                        if (gas > f[currentCar])
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            m[currentCar] += distance;
                            f[currentCar] -= gas;
                            Console.WriteLine($"{currentCar} driven for {distance} kilometers. {gas} liters of fuel consumed.");
                        }
                        if (m[currentCar] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {currentCar}!");
                            m.Remove(currentCar);
                            f.Remove(currentCar);
                        }
                        break;
                    case "Refuel":
                        
                        int fuel = int.Parse(cmdArgs[2]);
                        int currentFuel = f[currentCar];
                        f[currentCar] += fuel;
                        if (f[currentCar] > 75)
                        {
                            f[currentCar] = 75;
                            fuel = 75 - currentFuel;

                        }
                        Console.WriteLine($"{currentCar} refueled with {fuel} liters");
                        break;
                    case "Revert":
                        int km = int.Parse(cmdArgs[2]);
                        m[currentCar] -= km;
                        if (m[currentCar] < 10000)
                        {
                            m[currentCar] = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{currentCar} mileage decreased by {km} kilometers");
                        }
                        break;
                    default:
                        break;
                }
                

                input = Console.ReadLine();
            }
            foreach (var item in m.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value} kms, Fuel in the tank: {f[item.Key]} lt.");
            }
        }
    }
}
