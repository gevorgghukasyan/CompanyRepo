namespace DavidHomework28_2
{
    internal abstract class Game
    {
        protected abstract string Name { get; set; }
        protected abstract int Money { get; set; }

        public abstract void Play();

        public string ShowBalance()
        {
            return $"Balance: {Money}";
        }

        protected string DisplayWelcomeMessage()
        {
            return $"Welcome in {Name} game";
        }
    }
}
