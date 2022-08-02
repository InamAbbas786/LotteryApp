using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace LotteryApp.Helpers
{
    public static class Calculator
    {
        public static double C(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        private static double Factorial(double i)
        {
            if (i <= 1)
            {
                return 1;
            }
            return i * Factorial(i - 1);
        }
    }
}
