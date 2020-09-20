using System;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace SimpleFactory
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
    public class Rectangle : Shape
    {
        public double width;
        public double length;
        public Rectangle(double width, double length)
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
    public class ShapeFactory
    {
        public static Shape GetShape(string type)
        {
            Shape shape = null;
            Random random = new Random();
            double randnum = random.Next(0,10);
            switch (type)
            {
                case "Circle":
                    
                    shape = new Circle(randnum);
                    break;
                case "Square":
                    shape = new Square(randnum);
                    break;
                case "Rectangle":
                    shape = new Rectangle(randnum, randnum);
                    break;

            }
            return shape;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape;
            shape = ShapeFactory.GetShape("Circle");
            Console.WriteLine(shape.GetArea());
        }
    }
}
