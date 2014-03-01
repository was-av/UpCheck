// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectIsNotFoundByNameException.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ObjectIsNotFoundByNameException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Exception
{
    using Common.Exception;

    /// <summary>
    /// The get data table exception.
    /// </summary>
    public class ObjectIsNotFoundByNameException : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Common.DAL.Exception.ObjectIsNotFoundByNameException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ObjectIsNotFoundByNameException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.DAL.Exception.ObjectIsNotFoundByNameException"/> class.
        /// </summary>
        public ObjectIsNotFoundByNameException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.DAL.Exception.ObjectIsNotFoundByNameException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public ObjectIsNotFoundByNameException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected override void SetExceptionMessage()
        {
            this.exceptionMessage = "Object of type [typeName] is not found by name [name]";
        }
    }
}

