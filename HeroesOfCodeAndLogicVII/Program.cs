using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string hero = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);
                if (mp <= 200 && hp <= 100)
                {
                    Hero currentHero = new Hero(hero, hp, mp);
                    heroes.Add(hero, currentHero);
                }
            }

            string commands = Console.ReadLine();

            while (commands != "End")
            {
                string[] cmdArgs = commands.Split(" - ");
                string command = cmdArgs[0];
                string heroName = cmdArgs[1];

                switch (command)
                {
                    case "CastSpell":
                        if (heroes[heroName].MP >= int.Parse(cmdArgs[2]))
                        {
                            Console.WriteLine($"{heroName} has successfully cast {cmdArgs[3]} and now has {heroes[heroName].MP- int.Parse(cmdArgs[2])} MP!");
                            heroes[heroName].MP -= int.Parse(cmdArgs[2]);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {cmdArgs[3]}!");
                        }
                        break;
                    case "TakeDamage":
                        heroes[heroName].HP -= int.Parse(cmdArgs[2]);

                        if (heroes[heroName].HP > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {int.Parse(cmdArgs[2])} HP by {cmdArgs[3]} and now has {heroes[heroName].HP} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {cmdArgs[3]}!");
                            heroes.Remove(heroName);
                        }
                        break;
                    case "Recharge":

                        int currentMp = heroes[heroName].MP;
                        if (heroes[heroName].MP+ int.Parse(cmdArgs[2]) > 200)
                        {
                            heroes[heroName].MP = 200;
                        }
                        else
                        {
                            heroes[heroName].MP += int.Parse(cmdArgs[2]);
                        }
                        Console.WriteLine($"{heroName} recharged for {heroes[heroName].MP-currentMp} MP!");
                        break;
                    case "Heal":
                        int currentHp = heroes[heroName].HP;
                        if (heroes[heroName].HP + int.Parse(cmdArgs[2]) > 100)
                        {
                            heroes[heroName].HP = 100;
                        }
                        else
                        {
                            heroes[heroName].HP += int.Parse(cmdArgs[2]);
                        }
                        Console.WriteLine($"{heroName} healed for {heroes[heroName].HP - currentHp} HP!");
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine();
            }
            foreach (var item in heroes.OrderByDescending(x => x.Value.HP).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Value);
            }


        }
        public class Hero
        {
            // Constructor that takes no arguments:
            public Hero(string name, int hp, int mp)
            {
                Name = name;          
                HP = hp;
                MP = mp;
            }

        // Auto-implemented readonly property:
        public string Name { get; set; }
            public int HP { get; set; }
            public int MP { get; set; }


            // Method that overrides the base class (System.Object) implementation.
            public override string ToString()
            {
                return $"{Name}\n  HP: {HP}\n  MP: {MP}";
            }
        }
    }
}
