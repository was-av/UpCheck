// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldUniquenessViolation.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the FieldUniquenessViolation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Exception
{
    using Common.Exception;

    /// <summary>
    /// The field uniqueness violation.
    /// </summary>
    public class FieldUniquenessViolation : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldUniquenessViolation"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public FieldUniquenessViolation(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldUniquenessViolation"/> class.
        /// </summary>
        public FieldUniquenessViolation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldUniquenessViolation"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public FieldUniquenessViolation(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMessage = "Field linked with the property [property] of the [type] is expected to be unique";
        }
    }
}
