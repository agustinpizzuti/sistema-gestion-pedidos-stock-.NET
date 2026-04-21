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
    public class Comun:Order
    {
        public Comun() { }

        public Comun(int id, DateTime cd, DateTime dd, int idClient, Client cli,List<Line> l, bool c, bool d, double fp, bool e) : base(id, cd, dd, idClient,cli, l, c,d,fp,e)
        {
            this.delivered = false;
            

            //AsignPrice();
            //IsValid();   
        }

        public override void IsValidWithSettings(IRepositorySetting repositorySetting)
        {
            if (DeliveryDateValid(repositorySetting)) 
            { throw new OrderException("La fecha de entrega del pedido no puede ser menor a una diferencia de siete dias con la creacion del mismo para un pedido comun"); }

            if (CompareDates()) { throw new OrderException("La fecha de entrega del pedido no puede ser anterior a la fecha de creacion"); }

            if (LineValidator()) { throw new OrderException("No puede haber un pedido sin articulos"); }
        }

        public override bool DeliveryDateValid(IRepositorySetting repositorySetting)
        {
            bool ok = false;
            int daysGap = (this.deliveryDate - this.creationDate).Days;

            if (daysGap < repositorySetting.getValueByName("DiaMinimoComun"))
            {
                ok = true;
            }

            //if (daysGap < 7)
            //{
            //    ok = true;
            //}

            return ok;
        }

        public override bool CompareDates() 
        {
            bool ok = false;

            if (this.deliveryDate < this.creationDate)
            {
                ok = true;
            }

            return ok;
        }

        public override void AsignPrice(IRepositorySetting repositorySetting)
        {
            double totalItems = 0;
            double recargoCalculado = 1 + (repositorySetting.getValueByName("RecargoComun") / 100);
            double IVACalculado = 1 + (repositorySetting.getValueByName("IVA") / 100);

            foreach (Line l in lines)
            {
                totalItems += l.price;
            }

            if (this.client.distance > repositorySetting.getValueByName("Distancia"))
            {
                totalItems = totalItems * recargoCalculado;
            }

            this.finalPrice = totalItems * IVACalculado;
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
