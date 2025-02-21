using System;

public class Bet
{
    public int Amount;

    public Bet(int amount)
    {
        Amount = amount;
    }

    public virtual bool IsWinningBet(int diceRoll)
    {
        return false;
    }

    public virtual int Payout()
    {
        return Amount * 2;
    }
}

public class NumberBet : Bet
{
    private int Number;

    public NumberBet(int amount, int number) : base(amount)
    {
        Number = number;
    }

    public override bool IsWinningBet(int diceRoll)
    {
        return diceRoll == Number;
    }

    public override int Payout()
    {
        return Amount * 6;
    }
}
public class OddBet : Bet
{
    public OddBet(int amount) : base(amount) { }

    public override bool IsWinningBet(int diceRoll)
    {
        return diceRoll % 2 != 0;
    }
}

public class EvenBet : Bet
{
    public EvenBet(int amount) : base(amount) { }

    public override bool IsWinningBet(int diceRoll)
    {
        return diceRoll % 2 == 0;
    }
}

public abstract class Casino
{
    private int playerBalance;
    private Random random = new Random();

    public Casino(int initialBalance)
    {
        playerBalance = initialBalance;
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Current Balance: {playerBalance} units\n");
    }

    public void PlaceBet(Bet bet)
    {
        if (bet == null || bet.Amount > playerBalance)
        {
            Console.WriteLine("Invalid bet or insufficient balance.");
            return;
        }

        playerBalance -= bet.Amount;
        int diceRoll = random.Next(1, 7);
        Console.WriteLine($"Dice rolled: {diceRoll}");

        if (bet.IsWinningBet(diceRoll))
        {
            int winnings = bet.Payout();
            Console.WriteLine($"You won! You gain {winnings} units.");
            playerBalance += winnings;
        }
        else
        {
            Console.WriteLine("You lost the bet.");
        }
    }

    public bool Balance()
    {
        return playerBalance > 0;
    }
}

public class GameCasino : Casino
{
    public GameCasino(int initialBalance) : base(initialBalance) { }
}

public class MiniDiceCasino
{
    public static void Main()
    {
        GameCasino casino = new GameCasino(100);
        bool playing = true;

        while (playing && casino.Balance())
        {
            casino.ShowBalance();
            Console.WriteLine("Choose bet type:");
            Console.WriteLine("1. Bet on Specific Number (1-6)");
            Console.WriteLine("2. Bet on Odd");
            Console.WriteLine("3. Bet on Even");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Bet bet = null;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the number (1-6): ");
                    int number = int.Parse(Console.ReadLine());
                    Console.Write("Enter bet amount: ");
                    int amountNumber = int.Parse(Console.ReadLine());
                    bet = new NumberBet(amountNumber, number);
                    break;
                case "2":
                    Console.Write("Enter bet amount: ");
                    int amountOdd = int.Parse(Console.ReadLine());
                    bet = new OddBet(amountOdd);
                    break;
                case "3":
                    Console.Write("Enter bet amount: ");
                    int amountEven = int.Parse(Console.ReadLine());
                    bet = new EvenBet(amountEven);
                    break;
                case "4":
                    playing = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            casino.PlaceBet(bet);
        }
    }
}
