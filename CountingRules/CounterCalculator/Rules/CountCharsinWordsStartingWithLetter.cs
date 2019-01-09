using CountingRules.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingRules.Rules
{
    public class CountCharsinWordsStartingWithLetter : RulesBase
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
                return Settings.Default.IsCountCharsinWordsStartingWithLetterApplicable;
            }
            set
            {
                Settings.Default.IsCountCharsinWordsStartingWithLetterApplicable = value;
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
                return Settings.Default.CountCharsinWordsStartingWithLetterResultFile;
            }
        }

        /// <summary>
        ///     Applies the rule on specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        public override void Apply(IList<string> words)
        {
            int charCount = 0;
            // First character is the character to select the words that start with..
            char startingCharacter = Characters.First();
            // Second character is the one to be searched in words.
            var characterToSearchInWords = Characters.Last();
            if (words.Any())
            {
                var applicableWords = words.Where(s => s.Trim().StartsWith(startingCharacter.ToString(), StringComparison.CurrentCultureIgnoreCase));
                foreach (var word in applicableWords)
                {
                    charCount = charCount + word.Count(x => char.ToUpperInvariant(x) == char.ToUpperInvariant(characterToSearchInWords));
                }
            }

            FileWriter.Instance.WriteToTextFile(ResultFileName, new List<string> { charCount.ToString() });
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
