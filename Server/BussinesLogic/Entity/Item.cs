using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.ItemException;
using BussinesLogic.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    [Index(nameof(name), IsUnique = true)]
    [Index(nameof(code), IsUnique = true)]
    public class Item:IValidableWithSettings
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "El nombre debe comprender un largo de entre 10 y 200 caracteres")]
        public string name { get; set; }

        [MinLength(5,ErrorMessage ="La descripcion debe tener un minimo de 5 caracteres")]
        public string description { get; set; }

        [StringLength(13,MinimumLength =13 ,ErrorMessage ="El codigo de barras debe ser de 13 caracteres")]
        public string code { get; set; }
        
        [Range(0,int.MaxValue, ErrorMessage ="El precio debe ser positivo o cero")]
        public double price { get; set; }

        public Item() { }

        public Item(int i, string n, string d, string c, double p)
        {
            this.Id = i;
            this.name = n;
            this.description = d;
            this.code = c;
            this.price = p;
        }

        public void IsValidWithSettings(IRepositorySetting repositorySetting)
        {
            if (NameValidator(repositorySetting)) { throw new ItemException("El nombre debe comprender un largo de entre 10 y 200 caracteres y no puede estar vacio"); }

            if (DescriptionValidator(repositorySetting)) { throw new ItemException("La descripcion debe contener al menos 5 caracteres y no puede estar vacio"); }

            if (CodeValidator(repositorySetting)) { throw new ItemException("El codigo de barras debe ser de 13 caracteres y no puede estar vacio"); }

            if (Price()) { throw new ItemException("El precio debe ser un valor positivo o cero"); }
        }

        public bool NameValidator(IRepositorySetting repositorySetting) 
        {
            bool ok = false;

            if (string.IsNullOrEmpty(this.name) || this.name.Length < repositorySetting.getValueByName("LargoNombreItemMinimo") 
                || this.name.Length > repositorySetting.getValueByName("LargoNombreItemMaximo"))
            {
                ok = true;
            }

            return ok;
        }

        public bool DescriptionValidator(IRepositorySetting repositorySetting) 
        {
            bool ok = false;

            if (string.IsNullOrEmpty(this.description) || this.description.Length < repositorySetting.getValueByName("LargoDescrpicionArticulo"))
            {
                ok= true;
            }

            return ok;
        }

        public bool CodeValidator(IRepositorySetting repositorySetting) 
        {
            bool ok = false;

            if (string.IsNullOrEmpty(this.code) || this.code.Length != repositorySetting.getValueByName("CodigoArticulo"))
            {
                ok = true;
            }

            return ok;
        }

        public bool Price() 
        {
            bool ok = false;

            if (this.price < 0)
            {
                ok = true;
            }

            return ok;
        }
    }
}
