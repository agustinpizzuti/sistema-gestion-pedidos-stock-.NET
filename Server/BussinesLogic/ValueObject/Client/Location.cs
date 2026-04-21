using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.ClientException;
using BussinesLogic.Exceptions.UserException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.ValueObject.Client
{
    [Owned]
    public class Location : IValidable
    {
        public string street { get; private set; }
        public string number { get; private set; }
        public string city { get; private set; }

        public Location(string s, string n, string c)
        {
            street = s;
            number = n;
            city = c;

            IsValid();
        }

        protected Location()
        {
            street = "Sin calle";
            number = "Sin numero";
            city = "Sin ciudad";
        }

        public override bool Equals(object? obj)
        {
            try
            {
                if (obj == null) return false;
                Location other = obj as Location;
                return street.Equals(other.street) && number.Equals(other.number) && city.Equals(other.city);
            }
            catch
            {
                return false;
            }
        }

        public void IsValid()
        {
            if (string.IsNullOrEmpty(street)) throw new ClientException("La calle no puede estar vacia");
            if (string.IsNullOrEmpty(number)) throw new ClientException("El numero no puede estar vacio");
            if (string.IsNullOrEmpty(city)) throw new ClientException("La ciudad no puede estar vacia");
        }
    }
}
