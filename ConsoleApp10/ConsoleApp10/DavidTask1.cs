using System;

namespace ConsoleApp10
{
    internal class DavidTask1
    {
        public double RefTask(ref double x, ref double y)
        {
            x = Math.Pow(x, 2);
            y = Math.Pow(y, 2);
            return x + y;
        }
    }
}
