namespace DuckTypingInterface;
using System;

public interface IQuacker
{
    void Quack();
}

public class Duck : IQuacker
{
    public void Quack() => Console.WriteLine("Quack!");
}

public class RobotDuck : IQuacker
{
    public void Quack() => Console.WriteLine("Electronic quack!");
}

public class Toy
{
    public void Quack() => Console.WriteLine("Squeak!");
}

static class Interface
{
    static void MakeItQuack(IQuacker q)
    {
        q.Quack();  // Compile-time safety & polymorphism via interface
    }

    public static void Run()
    {
        MakeItQuack(new Duck());
        MakeItQuack(new RobotDuck());
        // MakeItQuack(new Toy()); // Compile error: Toy does not implement IQuacker
    }
}
