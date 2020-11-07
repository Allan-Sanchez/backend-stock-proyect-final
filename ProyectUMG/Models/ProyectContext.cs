using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectUMG.Models;

namespace ProyectUMG.Models
{
    public class ProyectContext : DbContext
    {
        public ProyectContext (DbContextOptions<ProyectContext> options) : base(options) 
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<StateBuy> StateBuy { get; set; }
        public DbSet<Buy> Buy { get; set; }




    }
}
