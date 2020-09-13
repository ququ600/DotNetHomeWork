using System;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Toeplitz
{
    class Program
    {

        static int[,] input()
        {
            Console.WriteLine("请输入你要创建矩阵的大小，先行后列");
            Console.WriteLine("行数是:");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("列数是:");
            int columns = Convert.ToInt32(Console.ReadLine());
            int[,] martix = new int[rows,columns];
            for(int i = 0; i < rows; i++)
            {
                Console.WriteLine("请输入第{0}行的值", i);
                string str = Console.ReadLine();
                string[] tempresult = str.Split(" ");
                for(int j = 0; j < columns; j++)
                {
                    martix[i, j] = Convert.ToInt32(tempresult[j]);
                }
            }
            return martix;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[,] Toeplitz = input();
            int row = Toeplitz.GetLength(0);
            int column = Toeplitz.GetLength(1);
            int flag = 0;
            for(int i = 0; i < row - 1; i++)
            {
                for(int j = 0; j < column - 1; j++)
                {
                    if (Toeplitz[i,j] != Toeplitz[i + 1,j + 1])
                    {
                        Console.WriteLine("false");
                        flag = 1;
                        break;
                    }
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("true");
            }
            }

    }
}
