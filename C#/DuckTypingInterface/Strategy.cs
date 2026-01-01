namespace DuckTypingInterface;
using System;

static class Strategy {

    public interface IValidator
    {
        bool Validate(string input);
    }

    public class NotEmptyValidator : IValidator
    {
        public bool Validate(string input) => !string.IsNullOrEmpty(input);
    }

    public class LengthValidator : IValidator
    {
        public int MinLength { get; }
        public LengthValidator(int min) => MinLength = min;
        public bool Validate(string input) => input?.Length >= MinLength;
    }

    public class FormProcessor
    {
        private readonly IValidator _validator;
        public FormProcessor(IValidator validator) => _validator = validator;
        public void Process(string data)
        {
            if (_validator.Validate(data))
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");
        }
    }

    public static void Run()
    {
        var processor1 = new FormProcessor(new NotEmptyValidator());
        var processor2 = new FormProcessor(new LengthValidator(5));

        processor1.Process("Hi");
        processor2.Process("Hi");  // invalid if < 5 chars
    }

}