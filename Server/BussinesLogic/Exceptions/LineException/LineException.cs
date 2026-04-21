using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Exceptions.LineException
{
    public class LineException:Exception
    {
        public LineException()
        {
        }

        public LineException(string? message) : base(message)
        {
        }

        public LineException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
