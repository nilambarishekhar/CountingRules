using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingRules
{
    public interface IRule
    {
        /// <summary>
        ///     Gets or sets the characters that are used for this Rule.
        /// </summary>
        IList<char> Characters { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is applicable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is applicable; otherwise, <c>false</c>.
        /// </value>
        bool IsApplicable { get; set; }

        /// <summary>
        /// Gets the name of the result file.
        /// </summary>
        /// <value>
        /// The name of the result file.
        /// </value>
        string ResultFileName { get; }

        /// <summary>
        ///     Applies the rule on specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        void Apply(IList<string> words);

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns>
        ///     IsValid as true in case the rule is applicable, else return Error Message or Exception details.
        /// </returns>
        ValidationResult Validate();
    }
}
