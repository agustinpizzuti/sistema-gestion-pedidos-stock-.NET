using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }      
        public string name { get; set; }      
        public string description { get; set; }      
        public string code { get; set; }
        public double price { get; set; }

        public ItemDTO() { }

        public ItemDTO(Item item)
        {
            if (item != null) 
            {
                this.Id = item.Id;
                this.name = item.name;
                this.description = item.description;
                this.code = item.code;
                this.price = item.price;
            }    
        }

    }
}
