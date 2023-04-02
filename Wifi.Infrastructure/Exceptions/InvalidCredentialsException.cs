using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Infrastructure.Exceptions
{

	[Serializable]
	public class InvalidCredentialsException : Exception
	{
		public InvalidCredentialsException() { }
		public InvalidCredentialsException(string message) : base(message) { }
		public InvalidCredentialsException(string message, Exception inner) : base(message, inner) { }
		protected InvalidCredentialsException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
