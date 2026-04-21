using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Exceptions.MovementType
{
    public class MovementTypeException:Exception
    {
        public MovementTypeException()
        {
        }

        public MovementTypeException(string? message) : base(message)
        {
        }

        public MovementTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovementTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
