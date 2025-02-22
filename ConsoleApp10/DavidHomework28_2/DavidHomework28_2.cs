namespace DavidHomework28_2
{
    internal class DavidHomework28_2
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("1. Slot Machine  |  2. BlackJack  |  0. Exit!\n" +
                    "Choose Game: ");
                string choose = Console.ReadLine();

                if (choose == "0")
                {
                    Console.WriteLine("Exit!...");
                    break;
                }

                switch (choose)
                {
                    case "1":
                        SlotMachine slot = new SlotMachine(5000);
                        slot.Play();
                        break;
                    case "2":
                        Blackjack blackjack = new Blackjack(5000);
                        blackjack.Play();
                        break;
                    default:
                        break;
                }

            }

        }
    }
}