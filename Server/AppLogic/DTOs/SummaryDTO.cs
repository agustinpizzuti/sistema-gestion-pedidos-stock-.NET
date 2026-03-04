using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class SummaryDTO
    {
        public int? year { get; set; }
        public int? amount { get; set; }
        public List<TypeAndAmount>? movements { get; set; }

        public SummaryDTO() { }

        public SummaryDTO(int y,int amount,List<TypeAndAmount> t) 
        {
            this.year = y; 
            this.amount = amount;
            this.movements = t;
        }
    }

    public class TypeAndAmount 
    {
        public string typeName { get; set; }
        public int amount { get; set; }
    }
}
