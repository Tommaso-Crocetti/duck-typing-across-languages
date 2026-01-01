namespace DuckTypingReflection;
using System;
using System.Reflection;

class Duck {
    public void Quack() => Console.WriteLine("Quack!");
}

class Person {
    public void Quack() => Console.WriteLine("The person imitates a duck!");
}

static class Reflection {

    static void TryQuack(object obj) {
        MethodInfo m = obj.GetType().GetMethod("Quack");
        if (m != null) {
            m.Invoke(obj, null);
        } else {
            Console.WriteLine($"{obj.GetType().Name} cannot quack!");
        }
    }

    public static void Run() {
        TryQuack(new Duck());   // Quack!
        TryQuack(new Person()); // The person imitates a duck!
        TryQuack(42);           // Int32 cannot quack.
    }
}