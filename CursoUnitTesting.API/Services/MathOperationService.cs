using System;

namespace CursoUnitTesting.API.Services
{
    public class MathOperationService
    {
        public MathOperationService()
        {
        }
        public static double Add(double number1, double number2)
        {
            return (number1 + number2);
        }

        public static double Subtract(double number1, double number2)
        {
            return (number1 - number2);
        }

        public static double Multiply(double number1, double number2)
        {
            return (number1 * number2);
        }

        public static double Divide(double number1, double number2)
        {
            return (number1 / number2);
        }

        public static bool IsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(candidate); divisor++)
            {
                if (candidate % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}