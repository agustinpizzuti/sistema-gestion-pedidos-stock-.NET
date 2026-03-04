using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.ClientException;
using BussinesLogic.RepositoryInterface;
using BussinesLogic.ValueObject.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    [Index(nameof(rut) ,IsUnique=true)]
    public class Client:IValidableWithSettings
    {
        public int Id { get; set; } 
        public string socialReason { get; set; }

        [StringLength(12, MinimumLength =12, ErrorMessage = "El root no puede estar vacio y debe ser de 12 caracteres")]
        public string rut { get; set; }
        public Location location { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La distancia no puede estar vacia o ser menor a cero")]
        public double distance { get; set; }

        public NombreCliente nombreCli { get; set; }

        public Client() { } 

        public Client(int id, string sr, string r, string sl,string nl,string cl, double d, string nc,string ac)
        {
            this.Id = id;
            this.socialReason = sr;
            this.rut = r;
            this.location = new Location(sl,nl,cl);
            this.distance = d;
            this.nombreCli = new NombreCliente(nc,ac);

            //IsValid();
        }

        public void IsValidWithSettings(IRepositorySetting repositorySetting) 
        {
            location.IsValid();
            nombreCli.IsValid();

            if (SocialReasonValidator()) { throw new ClientException("La razon social no puede estar vacia"); }

            if (RutValidator(repositorySetting)) { throw new ClientException("El root no puede estar vacio y debe ser de 12 caracteres"); }

            if (DistanceValidator()) { throw new ClientException("La distancia no puede estar vacia o ser menor a cero"); }
        }

        public bool SocialReasonValidator() 
        {
            if (string.IsNullOrEmpty(socialReason)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RutValidator(IRepositorySetting repositorySetting) 
        {
            if (string.IsNullOrEmpty(rut) || this.rut.Length != repositorySetting.getValueByName("Rut"))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool DistanceValidator() 
        {
            if (distance < 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }   
    }
}
