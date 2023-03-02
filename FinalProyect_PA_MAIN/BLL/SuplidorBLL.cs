using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
  
#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.BLL
{
    
    public class SuplidorBLL  // BLL Para Clientes
    {
        private ApplicationDbContext contexto;

        public SuplidorBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Suplidor.Any(c => c.SuplidorId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        public Suplidor ExisteNombreSuplidor(string Nombre)
        {
            Suplidor existe;

            try
            {
                existe = contexto.Suplidor              
                .Where( p => p.Nombre
                .ToLower() == Nombre.ToLower())
                .AsNoTracking()
                .SingleOrDefault();

            }catch
            {
                throw;
            }
            return existe;
        }

        public bool Guardar(Suplidor suplidor)
        {
            if (!Existe(suplidor.SuplidorId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }

        private bool Insertar(Suplidor suplidor)
        {
            bool Insertado = false;

            try
            {
                contexto.Suplidor.Add(suplidor);
                Insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Suplidor suplidor)
        {
            bool Insertado = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                Insertado =  contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Suplidor Buscar(int id)
        {
            return contexto.Suplidor
                .Where(s => s.SuplidorId == id && s.Estado == true)
                .SingleOrDefault();
        }
 
        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var suplidor = Buscar(id);

                if (suplidor != null)
                {
                    suplidor.Estado = false;
                    Eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Suplidor> GetList(Expression<Func<Suplidor, bool>> suplidor)
        {
            List<Suplidor> Lista = new List<Suplidor>();
            try
            {
                Lista = contexto.Suplidor
                .Where(c => c.Estado == true)
                .Where(suplidor)
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
