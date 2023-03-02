using Microsoft.AspNetCore.Mvc;
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
    public class VentasBLL // BLL para Ventas
    {
        private ApplicationDbContext contexto;

        public VentasBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            try
            {
                return contexto.Ventas.AsNoTracking().Any(p => p.VentaId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Guardar(Ventas ventas)
        {
        
            if (!Existe(ventas.VentaId))
                return  Insertar(ventas);
            else
                return  Modificar(ventas);
        }

        private bool Insertar(Ventas ventas)
        { 
            bool Insertado = false;

            try
            {
                if (contexto.Ventas.Add(ventas) != null)
                {
                    foreach (var item in ventas.ventasDetalle)
                    {
                        item.articulo.Cantidad -= item.Cantidad;
                    }
                    Insertado =  contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Ventas ventas)
        {
            bool Insertado = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM VentasDetalle Where VentaId = {ventas.VentaId}");
                foreach (var item in ventas.ventasDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;

                    item.articulo.Cantidad -= item.Cantidad;
                }

                contexto.Entry(ventas).State = EntityState.Modified;
                Insertado =  contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Ventas Buscar(int id)
         {
            Ventas ventas;

            try
            {
                ventas = contexto.Ventas
                .Include( e => e.ventasDetalle)
                .Where( e => e.VentaId == id && e.Estado == true).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return ventas;
        }

    
        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {           
               var venta = Buscar(id);

                if (venta != null)
                {      

                    foreach (var item in venta.ventasDetalle)
                    {
                        item.articulo.Cantidad += item.Cantidad;
                    }

                    venta.Estado = false;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Ventas> GetList(Expression<Func<Ventas, bool>> ventas)
        {
            List<Ventas> Lista = new List<Ventas>();
            try
            {
                Lista =  contexto.Ventas
                .Where(v => v.Estado == true)
                .Where(ventas)
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
