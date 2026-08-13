using System;
public sealed class Singleton
{
    private static Singleton instance = null;
    private Singleton()
    {
        Console.WriteLine("Singleton Instance Created");
    }
    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }
}
class Program
{
    static void Main()
    {
        Singleton obj1 = Singleton.GetInstance();
        Singleton obj2 = Singleton.GetInstance();

        Console.WriteLine(obj1 == obj2);
    }
}
