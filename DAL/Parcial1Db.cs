using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Parcial1Db : DbContext
    {
        public Parcial1Db() : base("ConStr")
        {

        }

        public DbSet<Presupuestos> Presupuesto { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}
