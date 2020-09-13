using System;

namespace PrimeFactor
{
    class Program
    {
        static bool isPrime(int a)
        {
            if (a == 2)
            {
                return true;
            }
            else
            {
                for(int i = 2; i < Math.Sqrt(a); i++)
                {
                    if (a % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要求的数字");
            int num = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                for(int i=2; i <= num; i++)
                {
                    if(num%i==0 && isPrime(i))
                    {
                        num = num / i;
                        Console.WriteLine("{0}", i);
                        break;
                    }
                }
                if (num == 1)
                {
                    break;
                }
            }
        }
    }
}
