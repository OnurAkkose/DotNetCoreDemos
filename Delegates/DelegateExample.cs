using System;

namespace Delegates
{
    public class DelegateExample
    {
        static void Main(string[] args)
        {

            MathTest math = new();
            math.calculateDelegate += math.Addition;
            math.calculateDelegate += math.Substraction;
            math.calculateDelegate += (int a, int b) => // lambda expression
            {
                Console.WriteLine("Divided");
                return a / b;
            };
            //math.calculateDelegate(5, 2);
            Delegate[] funcs = math.calculateDelegate.GetInvocationList();
        }
    }
    public class MathTest
    {
        public delegate int CalculateDelegate(int x1, int x2);
        public CalculateDelegate calculateDelegate;

        public int Addition(int a, int b)
        {
            Console.WriteLine("Added");
            return a + b;
        }
        public int Substraction(int a, int b)
        {
            Console.WriteLine("Substracted");
            return a - +b;
        }
    }
}
}

