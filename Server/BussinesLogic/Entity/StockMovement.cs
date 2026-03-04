using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.StockMovement;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    public class StockMovement:IValidableWithSettings
    {
        public int Id{ get; set; }
        public DateTime dateOfMovement { get; set; }
        
        [ForeignKey(nameof(item))]public int itemID { get; set; }
        public Item item { get; set; }
        public string mailUser { get; set; }

        [ForeignKey(nameof(movementType))]public int movementTypeID { get; set; }
        public MovementType movementType { get; set; }

        public int amount { get; set; }

        public StockMovement() { }

        public StockMovement(int id, DateTime dateOfMovement, int itemID, Item item, string mail, int movementTypeID, MovementType movementType, int amount)
        {
            Id = id;
            this.dateOfMovement = dateOfMovement;
            this.itemID = itemID;
            this.item = item;
            this.mailUser = mail;
            this.movementTypeID = movementTypeID;
            this.movementType = movementType;
            this.amount = amount;

        }

        public void IsValidWithSettings(IRepositorySetting repositorySetting)
        {
            if (AmountValidator(repositorySetting)) { throw new StockMovementException("La cantidad ingresada no puede ser mayor al tope (10) o menor a cero"); }
            
        }

        public bool AmountValidator(IRepositorySetting repositorySetting) 
        {
            bool ok = false;

            if (amount > repositorySetting.getValueByName("TopeMovimiento") || amount < 0) 
            {
                ok = true;
            }

            return ok;
        }

        
    }
}
