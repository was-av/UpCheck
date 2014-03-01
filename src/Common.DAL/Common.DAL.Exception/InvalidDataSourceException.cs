// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidDataSourceException.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the InvalidDataSourceException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Exception
{
    using Common.Exception;

    /// <summary>
    /// The get data table exception.
    /// </summary>
    public class InvalidDataSourceException : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Common.DAL.Exception.InvalidDataSourceException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidDataSourceException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.DAL.Exception.InvalidDataSourceException"/> class.
        /// </summary>
        public InvalidDataSourceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.DAL.Exception.InvalidDataSourceException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public InvalidDataSourceException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMessage = "Attempt to get datasource: [datasource] using connection: [connection] causes exception";
        }
    }
}

