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
    
    public class ClientesBLL  // BLL Para Clientes
    {
        private ApplicationDbContext contexto;

        public ClientesBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

          private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Clientes.Any(c => c.ClienteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

       

         public Clientes ExisteCedula(string Cedula)
        {
            Clientes existe;

            try
            {
                existe = contexto.Clientes               
                .Where( p => p.Cedula
                .ToLower() == Cedula.ToLower())
                .AsNoTracking()
                .SingleOrDefault();

            }catch
            {
                throw;
            }
            return existe;
        }

        public bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.ClienteId))
                return Insertar(clientes);
            else
                return Modificar(clientes);
        }

      

        private bool Insertar(Clientes clientes)
        {
            bool Insertado = false;

            try
            {
                contexto.Clientes.Add(clientes);
                Insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Clientes clientes)
        {
            bool Insertado = false;

            try
            {
                contexto.Entry(clientes).State = EntityState.Modified;
                Insertado =  contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Clientes Buscar(int id)
        {
            return contexto.Clientes
                .Where(a => a.ClienteId == id && a.Estado == true)
                .SingleOrDefault();
        }
 
        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var cliente = Buscar(id);

                if (cliente != null)
                {
                    cliente.Estado = false;
                    Eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Clientes> GetList(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            try
            {
                Lista = contexto.Clientes
                .Where(c => c.Estado == true)
                .Where(cliente)
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
