using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Robot warrior = new WarriorRobot("WarriorBot");
            Robot defender = new DefenderRobot("DefenderBot");

            GameManager.StartBattle(warrior, defender);
            Console.ReadLine();
        }

        abstract class Robot
        {
            public string Name { get; set; }
            public int Energy { get; set; }
            public int AttackPower { get; set; }
            protected Robot(string name, int energy, int attackPower)
            {
                Name = name;
                Energy = energy;
                AttackPower = attackPower;
            }

            public abstract void Attack(Robot opponent);

            public bool IsAlive()
            {
                return Energy > 0;
            }
        }

        
    class WarriorRobot : Robot
    {
        private static Random random = new Random();

        public WarriorRobot(string name): base(name, 100, 20)
        {
        }
        public override void Attack(Robot opponent)
        {
            int damage = random.Next(10, 21);
            opponent.Energy -= damage;
            Console.WriteLine($"{Name} attacks {opponent.Name} for {damage} damage!");
        }
    }

    class DefenderRobot : Robot
    {
        private static Random random = new Random();

        public DefenderRobot(string name): base(name, 150, 10) 
        {
        }
        public override void Attack(Robot opponent)
        {
            int damage = random.Next(5, 11);
            opponent.Energy -= damage;
            Console.WriteLine($"{Name} attacks {opponent.Name} for {damage} damage!");
        }
    }
        interface IAttack
        {
            void Attack(Robot opponent);
        }


      
       static class GameManager
       {
        public static void StartBattle(Robot r1, Robot r2)
        {
            Console.WriteLine("Battle Start!");
            while (r1.IsAlive() && r2.IsAlive())
            {
                r1.Attack(r2);
                if (r2.IsAlive())
                {
                    r2.Attack(r1);
                }
                Console.WriteLine($"{r1.Name} Energy: {r1.Energy}");
                Console.WriteLine($"{r2.Name} Energy: {r2.Energy}");
                Console.WriteLine();
            }
            if (r1.IsAlive())
            {
                Console.WriteLine($"{r1.Name} wins the battle!");
            }
            else
            {
                Console.WriteLine($"{r2.Name} wins the battle!");
            }
        }
        }


    }
}
