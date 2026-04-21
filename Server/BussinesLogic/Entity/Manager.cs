using BussinesLogic.ValueObject.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entity
{
    public class Manager:User
    {
        public Manager() { }

        public Manager(int id,string mail,string name,string surename,string pass,string encrypt,bool isAdmin,bool isManager) :base(id,mail,name,surename,pass,encrypt,isAdmin,isManager) 
        {

        }
    }
}
