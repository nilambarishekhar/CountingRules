using System;

namespace CountingRules
{
    /// <summary>
    ///     This class provides information about validations and result of Validation summary.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; private set; }

        /// <summary>
        ///     Logs the success and sets this result to Valid.
        /// </summary>
        public void LogSuccess()
        {
            IsSuccess = true;
        }

        /// <summary>
        ///     Logs the error for the provided message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void LogError(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }
    }

    /// <summary>
    ///     This class provides the summary for result of the process / methods.
    /// </summary>
    /// <seealso cref="CountingRules.ValidationResult" />
    public class ReturnResult : ValidationResult
    {
        /// <summary>
        ///     Gets the exception information.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        ///     Logs the exception.
        /// </summary>
        /// <param name="ex">The exception information</param>
        public void LogException(Exception ex)
        {
            Exception = ex;
            LogError(ex.Message);
        }
    }
}