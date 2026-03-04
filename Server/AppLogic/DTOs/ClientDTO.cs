using BussinesLogic.Entity;
using BussinesLogic.ValueObject.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string socialReason { get; set; }     
        public string rut { get; set; }
        public string street { get; set; } 
        public string number { get; set; }
        public string city { get; set; }    
        public double distance { get; set; }
        public string name { get; set; }
        public string surename { get; set; }

        public ClientDTO() { }

        public ClientDTO(Client client) 
        {
            if (client != null) 
            {
                this.Id = client.Id;
                this.socialReason = client.socialReason;
                this.rut = client.rut;
                this.street=client.location.street;
                this.number = client.location.number;
                this.city = client.location.city;
                this.distance =client.distance;
                this.name =client.nombreCli.name;
                this.surename =client.nombreCli.surename;
            }
            
        }
    }
}
