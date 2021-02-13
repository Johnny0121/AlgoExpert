using System;

namespace ALGO.Problems
{
    // Problem: https://gyazo.com/fcdb586347830c2612352129c09ca04c
    public class NonConstructableChange : IProblem
    {
        private int[] Coins;

        public NonConstructableChange()
        {
            Coins = new int[] { 5, 7, 1, 1, 2, 3, 22 };
        }

        public void Run()
        {
            Console.WriteLine($"Minimum Change Cannot Create: {MinimumChangeCannotCreate(Coins)}");
        }

        private int MinimumChangeCannotCreate(int[] coins)
        {
            Array.Sort(coins);

            int validChange = 0;

            foreach (int coin in coins)
            {
                if (coin > validChange + 1)
                {
                    return validChange + 1;
                }
                else
                {
                    validChange += coin;
                }
            }

            return validChange + 1;
        }
    }
}
