using System;

namespace ShapeClass
{
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract bool IsLegal();
    }
    public class Circle : Shape
    {
        public double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public override bool IsLegal()
        {
            if (radius > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Square : Shape
    {
        public double length;
        public Square(double length)
        {
            this.length = length;
        }
        public override double GetArea()
        {
            return length * length; 
        }
        public override bool IsLegal()
        {
            if (length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Rectangle : Shape {
        public double width;
        public double length;
        public Rectangle(double width,double length)
        {
            this.width = width;
            this.length = length;
        }
        public override double GetArea()
        {
            return width * length;
        }
        public override bool IsLegal()
        {
            if (width != length && width > 0 && length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
