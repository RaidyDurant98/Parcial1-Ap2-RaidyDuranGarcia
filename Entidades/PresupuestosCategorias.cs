using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PresupuestosCategorias
    {
        [Key]
        public int Id { get; set; }
        public int PresupestoId { get; set; }
        public int CategoriaId { get; set; }
        public decimal Monto { get; set; }

        public Presupuestos Presupuesto { get; set; }

        public PresupuestosCategorias()
        {

        }

        public PresupuestosCategorias(int categoriaId, decimal monto)
        {
            this.CategoriaId = categoriaId;
            this.Monto = monto;
        }
    }
}
