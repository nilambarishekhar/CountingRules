using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CountingRules
{
    public class RulesManager
    {
        #region Constructor
        private static readonly Lazy<RulesManager> lazy = new Lazy<RulesManager>(() => new RulesManager());

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static RulesManager Instance { get { return lazy.Value; } }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RulesManager"/> class.
        /// </summary>
        private RulesManager()
        {
            var interfaceType = typeof(IRule);
            // In case all the types need to be loaded from Current Application domain
            //var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
            // Get types from current assembly
            var types = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            // Initialize all the classes from the current assembly
            RuleBook = types.ToDictionary(x => x.FullName, x => Activator.CreateInstance(x) as IRule);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the rule book.
        /// </summary>
        public IDictionary<string, IRule> RuleBook { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the rule by Rule Name.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <returns>The rule configured</returns>
        /// <exception cref="Exception">In case the input parameter is empty or no rule is found with the name specified.</exception>
        private IRule GetRule(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName))
                throw new Exception("Provide a valid RuleName");

            IRule rule;
            if (Instance.RuleBook.TryGetValue(ruleName, out rule))
                return rule;
            else
                throw new Exception(string.Format("No Rule exists with {0} name.", ruleName));
        }

        /// <summary>
        /// Enables the rule.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        public ReturnResult EnableRule(string ruleName)
        {
            var result = new ReturnResult();
            try
            {
                var ruleToApply = GetRule(ruleName);
                ruleToApply.IsApplicable = true;
                result.LogSuccess();
            }
            catch (Exception ex)
            {
                result.LogException(ex);
            }
            return result;
        }

        /// <summary>
        /// Disables the rule.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        public ReturnResult DisableRule(string ruleName)
        {
            var result = new ReturnResult();
            try
            {
                var ruleToApply = GetRule(ruleName);
                ruleToApply.IsApplicable = false;
                result.LogSuccess();
            }
            catch (Exception ex)
            {
                result.LogException(ex);
            }
            return result;
        }

        /// <summary>
        /// Applies the rule.
        /// </summary>
        /// <param name="ruleName">Name of the rule (Fully qualified name of rule with Namespace).</param>
        /// <param name="ruleChars">The rule chars.</param>
        /// <param name="wordsUnderRule">The words under rule.</param>
        public ReturnResult ApplyRule(string ruleName, IList<char> ruleChars, IList<string> wordsUnderRule)
        {
            var result = new ReturnResult();
            try
            {
                if (wordsUnderRule == null || !wordsUnderRule.Any())
                    throw new Exception("Provide valid value for words under rule.");

                var ruleToApply = GetRule(ruleName);
                if (!ruleToApply.IsApplicable)
                {
                    result.LogError(string.Format("Rule '{0}' is disabled.", ruleToApply.GetType().Name));
                    return result;
                }

                ruleToApply.Characters = ruleChars;
                var validationResult = ruleToApply.Validate();
                if (validationResult.IsSuccess)
                {
                    ruleToApply.Apply(wordsUnderRule);
                    result.LogSuccess();
                }
                else
                    result.LogError(validationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                result.LogException(ex);
            }
            return result;
        }
        #endregion
    }
}