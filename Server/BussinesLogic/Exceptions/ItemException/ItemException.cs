using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Exceptions.ItemException
{
    public class ItemException:Exception
    {
        public ItemException()
        {
        }

        public ItemException(string? message) : base(message)
        {
        }

        public ItemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
