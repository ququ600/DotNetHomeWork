using System;
using System.Collections.Generic;

namespace CalculateArray
{
    class Program
    {
        static private void Calculate(List<int> array)
        {
            int tempmax = 0;
            int tempmin = 0;
            int sum = 0;
            tempmin = array[0];
            foreach (int i in array)
            {
                if (i > tempmax)
                {
                    tempmax = i;
                }
                if (i < tempmin)
                {
                    tempmin = i;
                }
                sum += i;
            }
            Dictionary<string, double> keyValuePairs= new Dictionary<string, double>();
            keyValuePairs.Add("maxValue", tempmax);
            keyValuePairs.Add("minValue", tempmin);
            keyValuePairs.Add("averageValue", sum / array.Count);
            keyValuePairs.Add("sumValue", sum);
            foreach(KeyValuePair<string,double> kvp in keyValuePairs)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }


        }

        static void Main(string[] args)
        {

            Console.WriteLine("请输入数组，以空格隔开");
            string str = Console.ReadLine();
            string[] result = str.Split(' ');
            List<int> myArray = new List<int>();
            for(int i = 0; i < result.Length; i++)
            {
                myArray.Add(Convert.ToInt32(result[i]));
            }
            Calculate(myArray);           
        }
    }
}
