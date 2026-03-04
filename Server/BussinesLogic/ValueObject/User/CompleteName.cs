using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.UserException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.ValueObject.User
{
    [Owned]
    public class CompleteName : IValidable
    {
        public string name { get; private set; }
        public string surename { get; private set; }

        public CompleteName(string n, string s)
        {

            name = n;
            surename = s;
            IsValid();

        }

        protected CompleteName()
        {
            name = "Sin nombre";
            surename = "Sin apellido";
            IsValid();
        }

        public override bool Equals(object? obj)
        {
            try
            {
                if (obj == null) return false;
                CompleteName other = obj as CompleteName;
                return name.Equals(other.name) && surename.Equals(other.surename);
            }
            catch
            {
                return false;
            }
        }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(this.name)) throw new UserException("El nombre no puede estar vacio");
            if (string.IsNullOrEmpty(this.surename)) throw new UserException("El apellido no puede estar vacio");

            if (validator(this.name)) throw new UserException("El nombre no puede contener numeros y/o los caracteres no alfabeticos no pueden estar al inicio o al final");
            if (validator(this.surename)) throw new UserException("El apellido no puede contener numeros y/o los caracteres no alfabeticos no pueden estar al inicio o al fina");
        }

        public bool validator(string s)
        {
            char primerLetra = s[0];
            char ultimaLetra = s[s.Length - 1];
            bool ret = false;
            
            if (primerLetra.CompareTo(' ') == 0 || primerLetra.CompareTo('`') == 0 || primerLetra.CompareTo('-') == 0)
            {
                ret = true;
            }

            if(ultimaLetra.CompareTo(' ') == 0 || ultimaLetra.CompareTo('`') == 0 || ultimaLetra.CompareTo('-') == 0) 
            {
                ret = true;
            }

            bool tieneNum = s.Any(char.IsNumber);

            if (tieneNum) 
            {
                ret = true;
            }


            return ret;      
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
