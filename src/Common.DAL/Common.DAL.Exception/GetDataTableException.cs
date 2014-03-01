// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDataTableException.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GetDataTableException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Exception
{
    using Common.Exception;

    /// <summary>
    /// The get data table exception.
    /// </summary>
    public class GetDataTableException : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDataTableException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public GetDataTableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDataTableException"/> class.
        /// </summary>
        public GetDataTableException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDataTableException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public GetDataTableException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMessage = "Attempt to get table: [table] using connection: [connection] causes exception";
        }
    }
}
