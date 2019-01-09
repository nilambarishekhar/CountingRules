using CountingRules.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingRules.Rules
{
    public class LongestWordStartingwithLetter : RulesBase
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is applicable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is applicable; otherwise, <c>false</c>.
        /// </value>
        public override bool IsApplicable
        {
            get
            {
                return Settings.Default.IsLongestWordStartingwithLetterApplicable;
            }
            set
            {
                Settings.Default.IsLongestWordStartingwithLetterApplicable = value;
            }
        }

        /// <summary>
        ///     Gets the name of the result file.
        /// </summary>
        /// <value>
        ///     The name of the result file.
        /// </value>
        public override string ResultFileName
        {
            get
            {
                return Settings.Default.LongestWordStartingwithLetterResultFile;
            }
        }

        /// <summary>
        ///     Applies the rule on specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        public override void Apply(IList<string> words)
        {
            int longestWordlength = 0;
            if (words.Any())
            {
                var applicableWords = words.Where(s => s.StartsWithAny(Characters));
                foreach (var word in applicableWords)
                {
                    if(word.Length > longestWordlength)
                        longestWordlength = word.Length;
                }
            }

            FileWriter.Instance.WriteToTextFile(ResultFileName, new List<string> { longestWordlength.ToString() });
        }
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Finds the string that starts with either of the characters specified.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="characters">The characters to verify against.</param>
        /// <returns>
        ///     <c>true</c> if this string starts with either of the characters; otherwise, <c>false</c>.
        /// </returns>
        public static bool StartsWithAny(this string source, IEnumerable<char> characters)
        {
            foreach (var valueToCheck in characters)
            {
                if (source.Trim().StartsWith(valueToCheck.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }

            return false;
        }
    }
}