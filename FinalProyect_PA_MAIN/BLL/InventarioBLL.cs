using Microsoft.EntityFrameworkCore;
using Models;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
  
#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.BLL
{
    public class InventarioBLL // BLL Para Articulo
    {
        private ApplicationDbContext contexto;

        public InventarioBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Articulo.Any(c => c.ArticuloId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }
/*
         public Inventario ExisteNombre(string NombreProducto)
        {
            Articulo existe;

            try
            {
                existe = contexto.Inventario                
                .Where( p => p.NombreProducto
                .ToLower() == NombreProducto.ToLower())
                .AsNoTracking()
                .SingleOrDefault();

            }catch
            {
                throw;
            }
            return existe;
        }

        */

        public bool Guardar(Inventario inventario)
        {
             
            if (!Existe(inventario.InventarioId))
                return  Insertar(inventario);
            else
                return  Modificar(inventario);
        }

        

        private bool Insertar(Inventario inventario)
        {
            bool Insertado = false;

            try
            {
                if (contexto.Inventario.Add(inventario) != null)
                {
                    Insertado =  contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Inventario inventario)
        {
            bool Insertado = false;

            try
            {
                contexto.Entry(inventario).State = EntityState.Modified;
                Insertado = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Inventario Buscar(int id)
        {
            return contexto.Inventario
                .Where(a => a.InventarioId == id && a.Estado == true)
                .SingleOrDefault();
        }

        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var inventario = Buscar(id);

                if (inventario!= null)
                {
                    inventario.Estado = false;
                    Eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Inventario> GetList(Expression<Func<Inventario, bool>> inventario)
        {
            List<Inventario> Lista = new List<Inventario>();
            try
            {
                Lista = contexto.Inventario
                .Where(a => a.Estado == true)
                .Where(inventario)
                .AsNoTracking()
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
