using Microsoft.EntityFrameworkCore;
using Luis_P1_AP2.Data;
using Luis_P1_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
namespace Luis_P1_AP2.BLL
{
    public class ProductoBLL
    {
          
        public static bool Guardar( Producto producto)
        {
            if(!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private static bool Existe(int id)
        {
            bool existencia;
            Contexto contexto = new Contexto();

            try
            {
                existencia = contexto.producto.Any(p => p.ProductoId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return existencia;
        }

        private static bool Insertar(Producto producto)
        {
            bool guardado;
            Contexto contexto = new Contexto();

            try
            {
                contexto.producto.Add(producto);
                guardado = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }

         private static bool Modificar(Producto producto)
        {
            bool modificado;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public static bool Eliminar(int id)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {      
                var eliminar = contexto.producto.Find(id);

                if(eliminar != null)
                {
                    contexto.Entry(eliminar).State = EntityState.Deleted;
                    eliminado = (contexto.SaveChanges() > 0);
                }
                
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static Producto Buscar(int id)
        {
            Producto producto = new Producto();
            Contexto contexto = new Contexto();

            try
            {
                producto = contexto.producto.Find(id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return producto;
        }

        public static List<Producto> GetList(Expression<Func<Producto, bool>> expression)
        {
            List<Producto> lista = new List<Producto>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.producto.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}