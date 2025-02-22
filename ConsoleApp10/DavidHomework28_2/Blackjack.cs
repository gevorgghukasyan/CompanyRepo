namespace DavidHomework28_2
{
    internal class Blackjack : Game
    {
        private string _name;
        private int _money;
        public int DealerScore { get; set; }
        public int PlayerScore { get; set; }

        protected override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = "Blackjack";
            }
        }

        protected override int Money
        {
            get
            {
                return _money;
            }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Incorrect value of money");
                }
                _money = value;
            }
        }

        public Blackjack(int money)
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
            DealerScore = random.Next(4, 22);
            PlayerScore = random.Next(4, 22);
            Console.WriteLine($"Dealer: {DealerScore}  |  Player: {PlayerScore}");

            Console.WriteLine("Do you want one more card?\n" +
                "Note: For YES press 1, for NO press 0");
            int number = int.Parse(Console.ReadLine());

            if(number == 1)
            {
                DealerScore += random.Next(2, 11);
                PlayerScore += random.Next(2, 11);
                Console.WriteLine("One more card for each one added!");
            }

            Console.WriteLine($"Dealer: {DealerScore}  |  Player: {PlayerScore}");

            if(PlayerScore > DealerScore && PlayerScore <= 21)
            {
                Money = Money + bet * 2;
                Console.WriteLine($"\n\nVery Good! You win {bet * 2}! {ShowBalance()}");
            }
            else if(PlayerScore == DealerScore)
            {
                Money += bet;
                Console.WriteLine($"\n\nThe score is Draw! {bet} bet returned! {ShowBalance()}");
            }
            else
            {
                Console.WriteLine($"\n\nOoops! You lose {bet}! {ShowBalance()}");
            }
        }
    }
}
