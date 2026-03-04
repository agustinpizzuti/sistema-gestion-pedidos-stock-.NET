using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.OrderException;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    public class Express:Order
    {      
        public Express() { }

        public Express(int id,DateTime cd,DateTime dd,int idClient,Client cli,List<Line> l,bool c, bool d, double fp, bool e):base(id,cd,dd,idClient,cli,l,c,d,fp,e) 
        {        
            this.delivered = false;
        }

        public override void IsValidWithSettings(IRepositorySetting repositorySetting)
        {
            if (DeliveryDateValid(repositorySetting)) 
            { throw new OrderException("La fecha de entrega del pedido no puede superar los cinco dias desde su creacion para un pedido express"); }

            if (CompareDates()) { throw new OrderException("La fecha de entrega del pedido no puede ser anterior a la de creacion del pedido"); }

            if (LineValidator()) { throw new OrderException("No puede haber un pedido sin articulos"); }
        }

        public override bool DeliveryDateValid(IRepositorySetting repositorySetting)
        {
            bool ok = false;

            int daysGap = (this.deliveryDate - creationDate).Days;

            if (daysGap > repositorySetting.getValueByName("DiasMaximoExpress"))
            {
                ok = true;
            }

            return ok;
        }


        public override void AsignPrice(IRepositorySetting repositorySetting)
        {
            double totalItems = 0;
            double recargoCalculadoDia = 1 + (repositorySetting.getValueByName("RecargoExpressDia") /100);
            double recargoCalculadoEstandar = 1 + (repositorySetting.getValueByName("RecargoExpress") / 100);
            double IVACalculado = 1 + (repositorySetting.getValueByName("IVA") / 100);

            foreach (Line l in lines) 
            {
                totalItems+=l.price;
            }

            if (creationDate.Day == deliveryDate.Day && creationDate.Month == deliveryDate.Month && creationDate.Year == deliveryDate.Year)
            {
                totalItems = totalItems * recargoCalculadoDia;
            }
            else 
            {
                totalItems = totalItems * recargoCalculadoEstandar;
            }

            this.finalPrice = totalItems * IVACalculado;
        }

        public override bool CompareDates()
        {
            bool ok = false;

            if (DateTime.Compare(DateTime.Now, this.deliveryDate) > 1)
            {
                ok = true;
            }

            return ok;
        }

        public override bool LineValidator()
        {
            bool ok = false;

            if (lines.Count() < 1) 
            {
                ok = true;
            }

            return ok;
        }
    }
}
