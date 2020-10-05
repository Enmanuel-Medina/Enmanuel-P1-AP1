using System;
using System.Collections.Generic;
using System.Text;
using Primer_Parcial_A1.Entidades;
using Primer_Parcial_A1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Primer_Parcial_A1.UI.Ciudad;

namespace Primer_Parcial_A1.BLL
{
    class Ciudad_BLL
    {
        public static bool Guardar(Ciudad ciudad)
        {
            if (!Existe(ciudad.CiudadId))
                return Insertar(ciudad);
            else
                return Modificar(ciudad);
        }
        private static bool Insertar(Ciudad ciudad)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Ciudad.Add(ciudad);
                found = context.SaveChanges() > 0;

            }
            catch
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }
        public static bool Modificar(Ciudad ciudad)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                context.Entry(ciudad).State = EntityState.Modified;
                found = context.SaveChanges() > 0;

            }
            catch
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }
        public static bool Eliminar(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                var persona = context.Ciudad.Find(id);

                if (persona != null)
                {
                    context.Ciudad.Remove(persona);
                    found = context.SaveChanges() > 0;
                }

            }
            catch
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }

        internal static object Guardar(rCiudad ciudad)
        {
            throw new NotImplementedException();
        }

        public static Ciudad Buscar(int id)
        {
            Contexto context = new Contexto();
            Ciudad persona;

            try
            {
                persona = context.Ciudad.Find(id);

            }
            catch
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return persona;
        }
        public static bool Existe(int id)
        {
            Contexto context = new Contexto();
            bool found = false;

            try
            {
                found = context.Ciudad.Any(p => p.CiudadId == id);

            }
            catch
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return found;
        }

        public static List<Ciudad> GetList(Expression<Func<Ciudad, bool>> criterio)
        {
            List<Ciudad> list = new List<Ciudad>();
            Contexto context = new Contexto();

            try
            {
                list = context.Ciudad.Where(criterio).AsNoTracking().ToList<Ciudad>();

            }
            catch
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }

            return list;
        }
    }
}

