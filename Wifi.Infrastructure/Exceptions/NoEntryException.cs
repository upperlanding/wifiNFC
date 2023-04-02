using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Infrastructure.Exceptions
{

	[Serializable]
	public class NoEntryException : Exception
	{
		public NoEntryException() { }
		public NoEntryException(string message) : base(message) { }
		public NoEntryException(string message, Exception inner) : base(message, inner) { }
		protected NoEntryException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
