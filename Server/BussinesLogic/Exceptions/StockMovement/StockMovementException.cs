using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Exceptions.StockMovement
{
    public class StockMovementException:Exception
    {
        public StockMovementException()
        {
        }

        public StockMovementException(string? message) : base(message)
        {
        }

        public StockMovementException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StockMovementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
