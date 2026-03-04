using BussinesLogic.Entity;
using BussinesLogic.ValueObject.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public string pass { get; set; }
        public string encrypt { get; set; }
        public bool isAdmin { get; set; }
        public bool isManager { get; set; }
        public UserDTO() { }

        public UserDTO(User user) 
        {
            if (user != null) 
            {
                this.Id = user.Id;
                this.mail = user.mail;
                this.name = user.comName.name;
                this.surename = user.comName.surename;
                this.pass = user.pass;
                this.encrypt = user.encrypt;
                this.isAdmin = user.isAdmin;
                this.isManager = user.isManager;
            }
        }
    }
}
