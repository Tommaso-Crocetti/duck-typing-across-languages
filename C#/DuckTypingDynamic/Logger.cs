namespace DuckTypingDynamic;
using System;

static class Logger {

    static void LogMessage(dynamic logger, string message) {
        try {
            logger.Log(message);
        } catch {
            Console.WriteLine("Logger does not support Log()");
        }
    }

    class ConsoleLogger {
        public void Log(string m) => Console.WriteLine($"LOG: {m}");
    }

    public static void Run() {
        LogMessage(new ConsoleLogger(), "Started");
        // If passed something without Log(), a runtime exception is caught.
    }
}