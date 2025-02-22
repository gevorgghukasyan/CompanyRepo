namespace DavidHomework28_2
{
    internal class SlotMachine : Game
    {
        private string _name;
        private int _money;
        public int Random { get; set; }

        protected override string Name { get { return _name; } set { _name = "Slot Machine"; } }

        protected override int Money
        {
            get
            {
                return _money;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Incorrect value of money");
                }
                _money = value;
            }
        }

        public SlotMachine(int money)
        {
            Name = Name;
            Money = money;
        }

        public override void Play()
        {
            Console.WriteLine($"\n\n{DisplayWelcomeMessage()}\n\n");

            Console.Write($"{ShowBalance()}\n" +
                     $"Input bet: ");

            int bet = int.Parse(Console.ReadLine());
            Money -= bet;

            Random random = new Random();
            int number;
            for (int i = 0; i < 3; i++)
            {
                number = random.Next(1, 5);
                Console.ReadLine();
                Random = Random * 10 + number;
                Console.Write($"| {number} | ");
            }

            if (IsWin())
            {
                Money = Money + bet * 3;
                Console.WriteLine($"\n\nVery Good! You win {bet * 3}! {ShowBalance()}");
            }
            else
            {
                Console.WriteLine($"\n\nOoops! You lose {bet}! {ShowBalance()}");
            }
        }

        public bool IsWin()
        {
            for (int i = 0; i < Random.ToString().Length - 1; i++)
            {
                if (Random.ToString()[i] == Random.ToString()[i + 1])
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}
