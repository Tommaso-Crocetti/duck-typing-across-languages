namespace DuckTypingReflection;
using System;
using System.Reflection;

static class Enumerator {

    static void PrintItems(object collection) {

        MethodInfo getEnum = collection.GetType().GetMethod("GetEnumerator");
        
        if (getEnum != null) {

            object enumerator = getEnum.Invoke(collection, null);
            var moveNext = enumerator.GetType().GetMethod("MoveNext");
            var current = enumerator.GetType().GetProperty("Current");

            while ((bool)moveNext.Invoke(enumerator, null))
            {
                Console.WriteLine(current.GetValue(enumerator));
            }
        }
    }

    public static void Run() {
        // Works on types implementing GetEnumerator (including List<int>, arrays...)
        PrintItems(new[] { 1, 2, 3 });
    }
}