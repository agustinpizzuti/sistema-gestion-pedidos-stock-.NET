using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.LineException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    public class Line:IValidable
    {
        public int Id { get; set; }
        [ForeignKey(nameof(item))]public int idItem { get; set; }

        public Item item { get; set; }

        [Range(1,int.MaxValue ,ErrorMessage ="La cantidad no puede ser menor a uno")]
        public int amount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
        public double price { get; set; }

        public Line() { }

        public Line(int id,int idIt,Item item,int a) 
        {
            this.Id= id;
            this.idItem= idIt;
            this.item= item;
            this.amount= a;
            Price();

            IsValid();
        }
        public void IsValid()
        {
            if (ValidAmount()) { throw new LineException("La cantidad no puede ser menor a uno, por favor cree de nuevo su pedido"); }

            if (ValidPrice()) { throw new LineException("El precio no puede ser negativo, por favor cree de nuevo su pedido"); }
        }

        public void Price() 
        {
           this.price= amount*item.price;
        }

        public bool ValidAmount() 
        {
            bool ok = false;

            if (amount < 1) 
            {
                ok= true;
            }

            return ok;
        }      

        public bool ValidPrice() 
        {
            bool ok = false;

            if (price < 0) 
            {
                ok= true;
            }

            return ok;
        }
    }
}
