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
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        public Categorias Categoria { get; set; }

        public PresupuestosCategorias()
        {

        }

        public PresupuestosCategorias(int presupuestoId, int categoriaId, string descripcion, decimal monto)
        {
            this.PresupestoId = presupuestoId;
            this.CategoriaId = categoriaId;
            this.Descripcion = descripcion;
            this.Monto = monto;
        }
    }
}
