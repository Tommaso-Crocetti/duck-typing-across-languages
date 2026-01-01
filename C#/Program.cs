using DuckTypingDynamic;
using DuckTypingInterface;
using DuckTypingReflection;

class Program
{   

    static void Main()
    {
        Console.WriteLine("=== Duck Typing with Interfaces ===");
        Interface.Run();
        Strategy.Run();
        Console.WriteLine("\n=== Duck Typing with Reflection ===");
        Reflection.Run();
        Enumerator.Run();
        Console.WriteLine("\n=== Duck Typing with Dynamic ===");
        Dynamic.Run();
        Logger.Run();
    }
}