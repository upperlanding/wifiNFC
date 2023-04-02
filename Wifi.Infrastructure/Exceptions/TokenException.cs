using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Infrastructure.Exceptions
{

	[Serializable]
	public class TokenException : Exception
	{
		public TokenException() { }
		public TokenException(string message) : base(message) { }
		public TokenException(string message, Exception inner) : base(message, inner) { }
		protected TokenException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
