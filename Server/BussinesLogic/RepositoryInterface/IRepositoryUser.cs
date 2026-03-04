using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.RepositoryInterface
{
    public interface IRepositoryUser:IRepository<User>
    {
        public User FindByMail(string mail);

        public string Encrypt(string pass);

        public string Decrypt(string passEncrip);
    }
}
