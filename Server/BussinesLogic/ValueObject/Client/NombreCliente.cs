using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.ClientException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BussinesLogic.ValueObject.Client
{
    [Owned]
    public class NombreCliente:IValidable
    {

        public string name { get; private set; }
        public string surename { get; private set; }

        public NombreCliente(string name, string surename)
        {
            this.name = name;
            this.surename = surename;

            IsValid();
        }

        protected NombreCliente() 
        {
            this.name = "sin nombre";
            this.surename = "sin apellido";
        }
        public override bool Equals(object? obj)
        {
            try
            {
                if (obj == null) return false;
                NombreCliente other = obj as NombreCliente;
                return name.Equals(other.name) && surename.Equals(other.surename);
            }
            catch
            {
                return false;
            }
        }

        public void IsValid() 
        {
            if(NameAndSurenameValid()){ throw new ClientException("El nombre y/o el apellido no pueden estar vacios"); }
        }

        public bool NameAndSurenameValid() 
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surename))
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
