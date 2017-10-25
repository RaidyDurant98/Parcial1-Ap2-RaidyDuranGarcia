using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PresupuestoCategoriasBLL
    {
        public static bool Guardar(PresupuestosCategorias presupuestoCategoria)
        {
            using (var context = new Respository<PresupuestosCategorias>())
            {
                try
                {
                    if (Buscar(p => p.Id == presupuestoCategoria.Id) == null)
                    {
                        return context.Guardar(presupuestoCategoria);
                    }
                    else
                    {
                        return context.Modificar(presupuestoCategoria);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static PresupuestosCategorias Buscar(Expression<Func<PresupuestosCategorias, bool>> criterio)
        {
            using (var context = new Respository<PresupuestosCategorias>())
            {
                try
                {
                    return context.Buscar(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static bool Eliminar(PresupuestosCategorias presupuestoCategoria)
        {
            using (var context = new Respository<PresupuestosCategorias>())
            {
                try
                {
                    return context.Eliminar(presupuestoCategoria);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<PresupuestosCategorias> GetListAll()
        {
            using (var context = new Respository<PresupuestosCategorias>())
            {
                try
                {
                    return context.GetListAll();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<PresupuestosCategorias> GetList(Expression<Func<PresupuestosCategorias, bool>> criterio)
        {
            using (var context = new Respository<PresupuestosCategorias>())
            {
                try
                {
                    return context.GetList(criterio);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
