using BussinesLogic.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDataAccess.Context
{
    public class PaperFactoryContext:DbContext
    {
        public DbSet<Item> items { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Manager> manager { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Express> express{ get; set; }
        public DbSet<Comun> comun { get; set; } 
        public DbSet<Setting> settings { get; set; }
        public DbSet<StockMovement> stocksMovement { get; set; }
        public DbSet<MovementType> movementsType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER = (localdb)\MsSqlLocalDb; DATABASE = papeleria; Integrated Security = true;");
        }
    }
}
