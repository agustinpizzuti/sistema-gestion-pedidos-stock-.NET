using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.UserException;
using BussinesLogic.RepositoryInterface;
using BussinesLogic.ValueObject.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BussinesLogic.Entity
{
    [Index(nameof(mail), IsUnique = true)]
    public abstract class User : IValidableWithSettings
    {
        public int Id { get; set; }
        public string mail { get; set; }
        public CompleteName comName { get; set; }

        [MinLength(6, ErrorMessage = "La contraseña debe tener 6 caracteres como minimo")]
        public string pass { get; set; }
        public string encrypt { get; set; }
        public bool isAdmin { get; set; }
        public bool isManager { get; set; }

        public User()
        {

        }

        public User(int i, string e, string n, string s, string p, string ep, bool a,bool m)
        {
            this.Id = i;
            this.mail = e;
            this.comName = new CompleteName(n, s);
            this.pass = p;
            this.encrypt = ep;
            this.isAdmin = a;
            this.isManager = m;
        }


        public void IsValidWithSettings(IRepositorySetting repositorySettings)
        {
            this.comName.IsValid();

            if (MailValidator()) throw new UserException("El mail debe contener arroba a excepcion del principio y el final y debe terminar en .com");

            if (PassValidator(repositorySettings)) 
            { 
                throw new UserException("La contraseña debe ser de un minimo 6 caracteres, contener una mayuscula" +
                    ", una minuscula, un numero y un simbolo de puntuacion: punto, punto y coma, " +
                    "simbolo de exclamacion de cierre y coma"); 
            }

            if (RolValidator()) { throw new UserException("El usuario solo puede tener un rol"); }

            if (EmptyRoleValidator()) { throw new UserException("El usuario debe tener un rol"); }

        }

        public bool MailValidator()
        {
            bool ok = false;

            char primeraLetra = this.mail[0];
            char ultimaLetra  = this.mail[mail.Length - 1];
            string com = ".com";
            char arroba = '@';

            if (mail.Contains(arroba))
            {
                if (primeraLetra.CompareTo(arroba) == 0 || ultimaLetra.CompareTo(arroba) == 0)
                {
                    ok = true;
                }

                if (mail.Contains(com))
                {
                    char punto = mail[mail.Length - 4];
                    char c = mail[mail.Length - 3];
                    char o = mail[mail.Length - 2];
                    char m = mail[mail.Length - 1];

                    if (punto != com[0] || c != com[1] || o != com[2] || m != com[3])
                    {
                        ok = true;
                    }

                }
                else 
                {
                    ok = true;
                }
            }
            else
            {
                ok = true;
            }

            if (mail.Contains(' '))
            {
                ok = true;
            }

            return ok;
        }

        public bool PassValidator(IRepositorySetting repositorySetting) 
        {
            bool ok = false;

            if (pass.Length >= repositorySetting.getValueByName("LargoContrasenia"))
            {

                bool minus    = pass.Any(char.IsLower);
                bool mayus    = pass.Any(char.IsUpper);
                bool num      = pass.Any(char.IsDigit);
                bool especial = pass.Any(char.IsPunctuation);

                if (!minus || !mayus || !num || !especial)
                {
                    ok = true;
                }

            }
            else 
            {
                ok = true;
            }


            return ok;
        }

        public bool RolValidator() 
        {
            bool ok = false;

            if (isManager && isAdmin) 
            {
                ok = true;
            }

            return ok;
        }

        public bool EmptyRoleValidator() 
        {
            bool ok = false;

            if (!isAdmin && !isManager) 
            {
                ok = true;
            }

            return ok;
        }
    }
}
