using BussinesLogic.EntityInterface;
using BussinesLogic.RepositoryInterface;
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
    public abstract class Order:IValidableWithSettings
    {
        public int Id { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime deliveryDate { get; set; }
        [ForeignKey(nameof(client))] public int idClient { get; set; }
        public Client client { get; set; }
        public List<Line> lines { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El precio final no puede ser negativo")]
        public double finalPrice { get; set; }
        public bool cancel { get; set; }
        public bool delivered { get; set; }
        public bool isExrpress { get; set; }


        public Order() { }

        public Order(int id, DateTime cd, DateTime dd, int IDc, Client cli,List<Line> l, bool c, bool d, double fp, bool e) 
        {
            this.Id = id;
            this.creationDate = cd;
            this.deliveryDate = dd;
            this.idClient = IDc;
            this.client = cli;
            this.lines = l;
            this.cancel = c;
            this.delivered = d;
            this.finalPrice = fp;
            this.isExrpress = e;
        }

        public abstract void AsignPrice(IRepositorySetting repositorySetting);
        public abstract bool DeliveryDateValid(IRepositorySetting repositorySetting);
        public abstract bool CompareDates();
        public abstract bool LineValidator();
        public abstract void IsValidWithSettings(IRepositorySetting repositorySetting); 
    }
}
