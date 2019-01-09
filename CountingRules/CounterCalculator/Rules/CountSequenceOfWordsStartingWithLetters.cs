using CountingRules.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingRules.Rules
{
    public class CountSequenceOfWordsStartingWithLetters : RulesBase
    {
        /// <summary>
        /// Gets a value indicating whether this instance is applicable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is applicable; otherwise, <c>false</c>.
        /// </value>
        public override bool IsApplicable
        {
            get
            {
                return Settings.Default.IsCountSequenceOfWordsStartingWithLettersApplicable;
            }
            set
            {
                Settings.Default.IsCountSequenceOfWordsStartingWithLettersApplicable = value;
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
                return Settings.Default.CountSequenceOfWordsStartingWithLettersResultFile;
            }
        }

        /// <summary>
        ///     Applies the rule on specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        public override void Apply(IList<string> words)
        {
            int findings = 0;
            // First character is the character to select the words that start with..
            char startingCharacter = Characters.First();
            // Second character is the one to be searched in words.
            char secondCharacter = Characters.Last();
            if (words.Any())
            {
                var applicableWords = words.Where(s => s.Trim().StartsWith(startingCharacter.ToString(), StringComparison.CurrentCultureIgnoreCase));
                foreach (var word in applicableWords.Where(wr => wr.Count() > 1))
                {
                    char secondChar = word[1];
                    if(char.ToUpperInvariant(secondChar) == char.ToUpperInvariant(secondCharacter))
                        findings++;
                }
            }

            FileWriter.Instance.WriteToTextFile(ResultFileName, new List<string> { findings.ToString() });
        }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns>
        ///     IsValid as true in case the rule is applicable, else return Error Message or Exception details.
        /// </returns>
        public override ValidationResult Validate()
        {
            var result = base.Validate();
            if (!result.IsSuccess)
                return result;

            if (Characters.Count != 2)
                result.LogError(string.Format("Two characters need to be specified for the rule {0}.", GetType().Name));

            return result;
        }
    }
}