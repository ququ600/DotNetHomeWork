using System;
using System.Collections.Generic;

namespace Eratosthenes
{
    class Program
    {

      


        static void Main(string[] args)
        {
            bool[] isPrime = new bool[100];
            for(int i = 0; i <= 99; i++)
            {
                isPrime[i] = true;
            }
            isPrime[0] = isPrime[1] = false;

            for(int i = 2; i <= 99; i++)
            {
                if (isPrime[i])
                {
                    for(int j = 2 * i; j <= 99; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
                if (isPrime[i])
                {
                    Console.Write("{0} ", i);
                }
            }

        }
    }
}
