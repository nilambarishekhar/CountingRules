using CountingRules.Rules;
using System;
using System.Collections.Generic;

namespace CountingRules
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsUnderObservation = new List<string> { "Ash", "Cash", "Counting", "Zebra", "Australia", "Beamer", "bushes", "ant", "cartoon", "Rulebook", "a" };

            // Run the rules to validate
            var result = RulesManager.Instance.ApplyRule(typeof(AverageLengthofWordsStartingwithLetter).FullName, new List<char> { 'a' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);
            //Retry after enabling rule
            result = RulesManager.Instance.EnableRule(typeof(AverageLengthofWordsStartingwithLetter).FullName);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);
            result = RulesManager.Instance.ApplyRule(typeof(AverageLengthofWordsStartingwithLetter).FullName, new List<char> { 'r' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);

            // Try second rule
            result = RulesManager.Instance.ApplyRule(typeof(LongestWordStartingwithLetter).FullName, new List<char> { 'a', 'b', 'C' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);
            //Retry after disabling the rule
            result = RulesManager.Instance.DisableRule(typeof(LongestWordStartingwithLetter).FullName);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);
            result = RulesManager.Instance.ApplyRule(typeof(LongestWordStartingwithLetter).FullName, new List<char> { 'z', 'r' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);

            // Try Third rule
            result = RulesManager.Instance.ApplyRule(typeof(CountCharsinWordsStartingWithLetter).FullName, new List<char> { 'a', 'b', 'C' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);
            result = RulesManager.Instance.ApplyRule(typeof(CountCharsinWordsStartingWithLetter).FullName, new List<char> { 'a', 'S' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);

            // Try Fourth rule
            result = RulesManager.Instance.ApplyRule(typeof(CountSequenceOfWordsStartingWithLetters).FullName, new List<char> { 'a', 'U' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);
            result = RulesManager.Instance.ApplyRule(typeof(CountSequenceOfWordsStartingWithLetters).FullName, new List<char> { 'a', 'S', 'c' }, wordsUnderObservation);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorMessage);

            Console.Read();
        }
    }
}
