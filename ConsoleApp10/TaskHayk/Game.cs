using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHayk
{
    internal class Game
    {
        public void GameFunc()
        {
            //------------------ Slot Machine ----------------------------
            //Console.WriteLine("--------    Welcome to our Casino   ---------");
            //Console.WriteLine("Choose your lucky number");
            //int rnd = int.Parse(Console.ReadLine());
            //BaseGame machine = new SlotMachine(rnd);
            //machine.DisplayWelcomeMessage();


            //bool flag = true;
            //while (flag) 
            //{
            //    Console.WriteLine("Press 1: Start | Press 2: Exit ");
            //    int choice = int.Parse(Console.ReadLine());
            //    if (choice == 1)
            //    {
            //        machine.Play();
            //        Console.WriteLine("Choose your lucky number");
            //        rnd = int.Parse(Console.ReadLine());
            //        continue;
            //    }
            //    else if (choice == 2)
            //    {
            //        flag = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("You enter wrong number");
            //        continue;
            //    }
            //}

            //----------------- Black Jack ---------------------------
            Console.WriteLine("--------    Welcome to our Casino   ---------");
            BaseGame BJ = new Blackjack();
            
            bool flag = true;
            while (flag) 
            {
                
                Console.WriteLine("Press 1: Start | Press 2: Exit ");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    BJ.Play();
                }
                else if (option == 2) 
                {
                    flag = false;
                }
                else
                {
                    throw new Exception("Wrong option");
                }
            }

        }
    }

    abstract class BaseGame 
    {
        protected string Name { get; set; }

        public BaseGame(string name)
        {
            Name = name;
        }

        abstract public void Play();

        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the your Big Game");
        }

    }

    class SlotMachine : BaseGame
    {
       
        private int _random;

        public int Random
        {
            get
            {
               return _random;
            }
            set
            {
                if (value > 0 || value < 5)
                {
                    _random = value;
                }
                else
                {
                    throw new Exception("Number must be big than Zero and less than 5");
                }
            }
        }
        public SlotMachine(int rnd) : base("Slot Machine")
        {
            Random = rnd;
        }

        override public void Play() 
        {
            Random rnd = new Random();
            int num1 = rnd.Next(0,5);
            int num2 = rnd.Next(0, 5);
            int num3 = rnd.Next(0, 5);
            Console.Write($"{num1} | {num2} | {num3} \n");

            if(Random == num1 && Random == num2 && Random == num3)
            {
                Console.WriteLine("Congrat's!!! You win.");
            }
            else
            {
                Console.WriteLine("Unfortunately you lose. Lets try again.");
            }
        }
    }

    class Blackjack : BaseGame
    {
        public Blackjack():base("Black Jack") { }

        private int _random;

        public int Random
        {
            get
            {
                Random rnd=new Random();
                _random= rnd.Next(16,25);
                return _random;
            }
        }

        public override void Play()
        {
            Random rnd = new Random();
            int num = rnd.Next(16, 21);
            Console.WriteLine($"Player card : {Random}");
            Console.WriteLine($"Dealer card : {num}");
            if (Random > num || Random <= 21)
            {
                Console.WriteLine("Congrat's!!! You win.");
            }
            else if(Random == num)
            {
                Console.WriteLine("Draw, your bet is refunded");
            }
            else
            {
                Console.WriteLine("Unfortunately you lose. Lets try again.");
                Console.WriteLine();
            }
        }
    }
}
