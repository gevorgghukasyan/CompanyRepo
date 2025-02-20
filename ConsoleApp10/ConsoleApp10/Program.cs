using System.Collections.Generic;
using System;

namespace opp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Ero
			int option = 0;
			Casino casino = new Casino(100);
			Bet bet = null;
			do
			{
				Console.WriteLine("Take option");
				Console.WriteLine("1:NumberBet 2:OddBet 3:EvenBet");
				option = int.Parse(Console.ReadLine());
				Console.WriteLine("imput bet amount");
				int amount = int.Parse(Console.ReadLine());
				Console.WriteLine("Guess the number");
				int userNumber = int.Parse(Console.ReadLine());
				switch (option)
				{
					case 0:
						return;
					case 1:
						bet = new NumberBet(userNumber, amount);
						break;
					case 2:
						bet = new OddBet(amount);
						break;
					case 3:
						bet = new EvenBet(amount);
						break;
				}

				casino.PlaceBet(bet);
			} while (option != 0);
		}

		class A
		{
			private int x;
			private readonly int y;

			public A()
			{
				y = 10;
			}

			public void S()
			{
				x = 25;
			}
		}

		class Bet
		{
			public int Amount { get; set; }
			public Bet(int amount)
			{
				Amount = amount;
			}
			public virtual bool IsWinningBet(int diceRoll)
			{
				throw new NotImplementedException();
			}
			public virtual int Payout()
			{
				return Amount * 2;
			}
		}
		class NumberBet : Bet
		{
			public NumberBet(int number, int amount) : base(amount)
			{
				Number = number;
			}
			public int Number { get; set; }
			public override bool IsWinningBet(int DiceRole)
			{
				return DiceRole == Number;
			}
			public override int Payout()
			{
				return Amount * 6;
			}
		}
		class OddBet : Bet
		{
			public OddBet(int amount) : base(amount)
			{
			}
			public override bool IsWinningBet(int DiceRole)
			{
				return DiceRole % 2 != 0;
			}
		}
		class EvenBet : Bet
		{
			public EvenBet(int amount) : base(amount)
			{
			}
			public override bool IsWinningBet(int DiceRole)
			{
				return DiceRole % 2 == 0;
			}
		}
		class Casino
		{
			public Casino(int playerBalance)
			{
				PlayerBalance = playerBalance;
			}
			public int PlayerBalance { get; set; }
			public void PlaceBet(Bet bet)
			{
				if (PlayerBalance < bet.Amount)
				{
					throw new ArgumentException("you havenot money for playing");
				}
				PlayerBalance -= bet.Amount;
				Random random = new Random();
				int DiceRole = random.Next(1, 7);
				bool resalt = bet.IsWinningBet(DiceRole);
				if (resalt)
				{
					PlayerBalance += bet.Payout();
					Console.WriteLine($"you win: your balance is{PlayerBalance}");
				}
				else
				{
					PlayerBalance -= bet.Payout();
					Console.WriteLine($"you lose: your balance is{PlayerBalance}");
				}
			}
		}
	}
}