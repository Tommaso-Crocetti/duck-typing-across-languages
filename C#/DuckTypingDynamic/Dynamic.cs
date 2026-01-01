namespace DuckTypingDynamic;
using System;

static class Dynamic {
    class Duck {
        public void Quack() => Console.WriteLine("Quack!");
    }

    class Person {
        public void Quack() => Console.WriteLine("The person imitates a duck!");
    }

    static void MakeItQuack(dynamic obj) {
        try {
            obj.Quack();  // resolved at runtime
        } catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) {
            Console.WriteLine("This object does not quack.");
        }
    }

    public static void Run() {
        MakeItQuack(new Duck());   // Quack!
        MakeItQuack(new Person()); // The person imitates a duck!
        MakeItQuack(42);           // This object does not quack.
    }
}