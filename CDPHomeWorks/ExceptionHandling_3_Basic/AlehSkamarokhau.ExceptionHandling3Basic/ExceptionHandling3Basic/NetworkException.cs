using System;
using System.Runtime.Serialization;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// The exception class for network operations.
	/// </summary>
	/// <seealso cref="System.Exception" />
	[Serializable]
	public class NetworkException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkException"/> class.
		/// </summary>
		public NetworkException()
		{
			//Empty.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkException"/> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public NetworkException(string message) : base(message)
		{
			//Empty.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public NetworkException(string message, Exception innerException) : base(message, innerException)
		{
			//Empty.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkException"/> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		protected NetworkException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			//Empty.
		}
	}
}
