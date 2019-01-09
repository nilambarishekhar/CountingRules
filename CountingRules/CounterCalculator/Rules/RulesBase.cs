using System.Collections.Generic;
using System.Linq;

namespace CountingRules.Rules
{
    public abstract class RulesBase : IRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RulesBase"/> class.
        /// </summary>
        public RulesBase()
        {
            Characters = new List<char>();
        }

        /// <summary>
        ///     Gets or sets the characters that are used for this Rule.
        /// </summary>
        public IList<char> Characters { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is applicable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is applicable; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsApplicable { get; set; }

        /// <summary>
        /// Gets the name of the result file.
        /// </summary>
        /// <value>
        /// The name of the result file.
        /// </value>
        public abstract string ResultFileName { get; }

        /// <summary>
        ///     Applies the rule on specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        public abstract void Apply(IList<string> words);

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns>
        ///     IsValid as true in case the rule is applicable, else return Error Message or Exception details.
        /// </returns>
        public virtual ValidationResult Validate()
        {
            var result = new ValidationResult();
            if (!Characters.Any())
                result.LogError(string.Format("Atleast one character needs to be specified for the rule {0}.", GetType().Name));
            else
                result.LogSuccess();

            return result;
        }
    }
}
