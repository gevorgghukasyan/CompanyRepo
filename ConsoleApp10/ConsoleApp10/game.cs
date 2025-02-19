using System;

abstract class Game
{
    protected static decimal Balance = 1000;
    protected string Name { get; set; }

    protected Game(string name)
    {
        Name = name;
    }
    public static decimal GetBalance()
    {
        return Balance;
    }
    protected static void SetBalance(decimal value)
    {
        Balance = value;
    }

    protected void DisplayWelcomeMessage()
    {
        Console.WriteLine($"hello  {Name}!");
    }

    protected decimal PlaceBet()
    {
        decimal bet;
        do
        {
            Console.Write($"You have ${GetBalance()}. Enter your bet: ");
            if (!decimal.TryParse(Console.ReadLine(), out bet) || bet <= 0 || bet > GetBalance())
            {
                Console.WriteLine("Error");
            }
        } while (bet <= 0 || bet > GetBalance());

        SetBalance(GetBalance() - bet);
        return bet;
    }

    public abstract void Play();
}

class SlotMachine : Game
{
    private static readonly Random random = new Random();

    public SlotMachine() : base("Slot Machine") { }

    public override void Play()
    {
        DisplayWelcomeMessage();
        decimal bet = PlaceBet();

        int reel1 = random.Next(1, 5);
        int reel2 = random.Next(1, 5);
        int reel3 = random.Next(1, 5);

        Console.WriteLine($"Reels: {reel1} | {reel2} | {reel3}");

        if (reel1 == reel2 && reel2 == reel3)
        {
            decimal winnings = bet * 3;
            SetBalance(GetBalance() + winnings);
            Console.WriteLine($"You won! You earned ${winnings}!\n");
        }
        else
        {
            Console.WriteLine("You lost. Better luck next time!\n");
        }
    }
}

class Blackjack : Game
{
    private Random random = new Random();

    public Blackjack() : base("Blackjack") { }

    public override void Play()
    {
        DisplayWelcomeMessage();
        decimal bet = PlaceBet();

        int playerScore = random.Next(16, 23);
        int dealerScore = random.Next(16, 23);

        Console.WriteLine($" Player Score: {playerScore}");
        Console.WriteLine($"Dealer Score: {dealerScore}");

        if (playerScore > 21)
        {
            Console.WriteLine("You busted! Dealer wins.\n");
        }
        else if (dealerScore > 21 || playerScore > dealerScore)
        {
            decimal winnings = bet * 2;
            SetBalance(GetBalance() + winnings);
            Console.WriteLine($"Congratulations! You won ${winnings}!\n");
        }
        else if (playerScore < dealerScore)
        {
            Console.WriteLine("Dealer wins. Better luck next time!\n");
        }
        else
        {
            SetBalance(GetBalance() + bet);
            Console.WriteLine("It's a tie! Your bet is refunded.\n");
        }
    }
}

class game
{
    static void Main()
    {
        Console.Write("Enter your player name: ");
        string playerName = Console.ReadLine().Trim();
        Console.WriteLine($"Welcome, {playerName}! You start with $1000.");

        while (Game.GetBalance() > 0)
        {
            Console.WriteLine("\nenter game: \n1️ Slot Machine\n2️ Blackjack\n3️ Exit");

            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine().Trim();

            Game game = null;

            if (choice == "1")
            {
                game = new SlotMachine();
            }
            else if (choice == "2")
            {
                game = new Blackjack();
            }
            else if (choice == "3")
            {
                Console.WriteLine($"Thanks for playing, {playerName}! You finished with ${Game.GetBalance()}.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice! Please enter 1, 2, or 3.\n");
                continue;
            }

            game.Play();
        }

        if (Game.GetBalance() == 0)
        {
            Console.WriteLine("You ran out of money! Game over.");
        }
    }
}
