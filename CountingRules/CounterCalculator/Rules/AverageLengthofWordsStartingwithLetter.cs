using CountingRules.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingRules.Rules
{
    public class AverageLengthofWordsStartingwithLetter : RulesBase
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
                return Settings.Default.IsAverageLengthofWordsStartingwithLetterApplicable;
            }
            set
            {
                Settings.Default.IsAverageLengthofWordsStartingwithLetterApplicable = value;
            }
        }

        /// <summary>
        /// Gets the name of the result file.
        /// </summary>
        /// <value>
        /// The name of the result file.
        /// </value>
        public override string ResultFileName
        {
            get
            {
                return Settings.Default.AverageLengthofWordsStartingwithLetterResultFile;
            }
        }

        /// <summary>
        ///     Applies the rule on specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        public override void Apply(IList<string> words)
        {
            int length = 0;
            int averageLength = 0;
            if (words.Any())
            {
                var applicableWords = words.Where(s => s.Trim().StartsWith(Characters.First().ToString(), StringComparison.CurrentCultureIgnoreCase));
                foreach (var word in applicableWords)
                {
                    length = length + word.Length;
                }
                averageLength = length / applicableWords.Count();
            }

            FileWriter.Instance.WriteToTextFile(ResultFileName, new List<string> { averageLength.ToString() });
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

            if (Characters.Count != 1)
                result.LogError(string.Format("Only one character can be specified for the rule {0}.", GetType().Name));

            return result;
        }
    }
}
