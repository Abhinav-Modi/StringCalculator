using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class Calculator
    {
        public static int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var numbersAsStrings = ParseInput(input);
            return SumNumbers(numbersAsStrings);
        }

        private static IEnumerable<string> ParseInput(string input)
        {
            if (TryExtractDelimiter(input, out var delimiterPart, out var numbersPart))
            {
                return ParseWithDelimiter(delimiterPart, numbersPart);
            }

            // Default delimiters (comma and newline)
            return input.Split(',', '\n').Select(s => s.Trim());
        }

        private static bool TryExtractDelimiter(string input, out string delimiterPart, out string numbersPart)
        {
            delimiterPart = null;
            numbersPart = null;

            if (input.StartsWith("//"))
            {
                var delimiterEndIndex = input.IndexOf('\n');
                if (delimiterEndIndex != -1)
                {
                    delimiterPart = GetDelimiterPart(input, delimiterEndIndex);
                    numbersPart = GetNumbersPart(input, delimiterEndIndex);
                    return true;
                }
            }

            return false;
        }

        private static string GetDelimiterPart(string input, int delimiterEndIndex)
        {
            // Skips the "//" characters and part after the delimiter
            return input.Substring(2, delimiterEndIndex - 2);
        }

        private static string GetNumbersPart(string input, int delimiterEndIndex)
        {
            return input.Substring(delimiterEndIndex + 1);
        }

        private static IEnumerable<string> ParseWithDelimiter(string delimiterPart, string numbersPart)
        {
            if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
            {
                // Multiple delimiters
                var delimiters = delimiterPart.Trim('[', ']').Split("][").Select(d => d.Trim());
                return numbersPart.Split(delimiters.Concat(new[] { ",", "\n" }).ToArray(), StringSplitOptions.RemoveEmptyEntries)
                                  .Select(s => s.Trim());
            }
            else
            {
                // Single-character custom delimiter
                return numbersPart.Split(new string[] { delimiterPart, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(s => s.Trim());
            }
        }

        private static int SumNumbers(IEnumerable<string> numbersAsStrings)
        {
            var numbers = numbersAsStrings
                .Select(numberString => int.TryParse(numberString, out int number) ? number : 0)
                .ToList();

            ValidateNumbers(numbers);

            return numbers.Where(IsValidNumber).Sum();
        }

        private static void ValidateNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                ValidateNumber(number);
            }
        }

        private static bool IsValidNumber(int number)
        {
            return number <= 1000;
        }

        private static void ValidateNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Negatives not allowed");
            }
        }
    }
}
