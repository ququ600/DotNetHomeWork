using System;

namespace GenericList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }

    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public void ForEach(Action<T> action)
        {
            Node<T> point = head;
            while (point != null)
            {
                action(point.Data);
                point = point.Next;
            }

        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            genericList.Add(1);
            genericList.Add(2);
            genericList.Add(3);

            genericList.ForEach(d => Console.WriteLine(d));

            int maxvalue = 0;
            int minvalue = 100;
            int sum = 0;
            genericList.ForEach(d =>
            {
                if (d > maxvalue)
                {
                    maxvalue = d;
                }
                if (d < minvalue)
                {
                    minvalue = d;
                }
                sum += d;
            });
            Console.WriteLine(maxvalue);
            Console.WriteLine(minvalue);
            Console.WriteLine(sum);
        }
    }
}
