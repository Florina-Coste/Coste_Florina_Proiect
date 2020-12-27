using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coste_Florina_Proiect.Models;

namespace Coste_Florina_Proiect.Data
{
    public class Coste_Florina_ProiectContext : DbContext
    {
        public Coste_Florina_ProiectContext (DbContextOptions<Coste_Florina_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Coste_Florina_Proiect.Models.Clothes> Clothes { get; set; }

        public DbSet<Coste_Florina_Proiect.Models.Brand> Brand { get; set; }

        public DbSet<Coste_Florina_Proiect.Models.Category> Category { get; set; }
    }
}
