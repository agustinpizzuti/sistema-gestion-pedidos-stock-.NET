using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.MovementType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    [Index(nameof(name),IsUnique=true)]
    public class MovementType:IValidable
    {
        public int Id { get; set; }
        public string name { get; set; }

        public int sumOrSubstractStock { get; set; }

        public MovementType() { }

        public MovementType(int id, string name,int sumOrSub) 
        {
            this.Id = id;
            this.name = name;
            this.sumOrSubstractStock = sumOrSub;
        }

        public void IsValid()
        {
            if (String.IsNullOrEmpty(name)) { throw new MovementTypeException("El nombre no puede estar vacio o ser nulo"); }

            if (sumOrSubstractValidator()) { throw new MovementTypeException("El tipo de dato solo acepta los valores 1 (suma en el stock) y -1 (resta en el stock)"); }
        }

        public bool sumOrSubstractValidator()
        {
            bool ok = false;

            if (sumOrSubstractStock != 1 && sumOrSubstractStock != -1)
            {
                ok = true;
            }

            return ok;
        }
    }
}
