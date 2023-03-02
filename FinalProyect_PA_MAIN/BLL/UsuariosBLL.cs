using Microsoft.EntityFrameworkCore;
using Models;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
    
namespace ProyectoFinal.BLL
{
    public class UsuariosBLL
    {
        private ApplicationDbContext contexto;

        public UsuariosBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        public async Task<List<Usuarios>> GetList(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = await contexto.Usuarios
                .Where(usuario)
                .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}