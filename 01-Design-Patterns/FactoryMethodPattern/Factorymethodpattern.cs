using System;

interface IShape
{
    void Draw();
}

class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Rectangle");
    }
}

class ShapeFactory
{
    public static IShape GetShape(string shape)
    {
        if (shape == "Circle")
            return new Circle();
        return new Rectangle();
    }
}

class Program
{
    static void Main()
    {
        IShape shape = ShapeFactory.GetShape("Circle");
        shape.Draw();
    }
}
