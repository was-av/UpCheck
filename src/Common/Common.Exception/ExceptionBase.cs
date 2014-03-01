// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionBase.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Base class for custom exceptions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Exception
{
    using System;
    using System.Collections;

    /// <summary>
    /// Base class for custom exceptions.
    /// </summary>
    public abstract class ExceptionBase : ApplicationException
    {
        /// <summary>
        /// The exception message.
        /// </summary>
        protected string exceptionMessage = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ExceptionBase(string message)
            : base(message)
        {
            this.SetExceptionMessage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase"/> class.
        /// </summary>
        public ExceptionBase()
        {
            this.SetExceptionMessage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public ExceptionBase(string message, System.Exception innerException)
            : base(message, innerException)
        {
            this.SetExceptionMessage();
        }

        /// <summary>
        /// The get message.
        /// </summary>
        /// <returns>
        /// The message <see cref="string"/>.
        /// </returns>
        public string GetMessage()
        {
            string result = this.AddDetails(this.exceptionMessage);
            result = string.Format("{0} - {1}", result, this.Message);

            return result;
        }

        /// <summary>
        /// The set exception message.
        /// </summary>
        protected virtual void SetExceptionMessage()
        {
        }

        /// <summary>
        /// The add details.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// Exception message <see cref="string"/>.
        /// </returns>
        private string AddDetails(string message)
        {
            string messageResult = message;

            foreach (DictionaryEntry de in this.Data)
            {
                messageResult = messageResult.Replace("[" + de.Key + "]", "[" + de.Value + "]");
            }

            return messageResult;
        }
    }
}
