using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Infrastructure.Exceptions
{

	[Serializable]
	public class RoomNotFoundException : Exception
	{
		public RoomNotFoundException() { }
		public RoomNotFoundException(string message) : base(message) { }
		public RoomNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected RoomNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
