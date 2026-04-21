using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    public class Setting
    {
        [Key]
        public string settingName { get; set; } 
        public double settingValue { get; set; }
    }
}
