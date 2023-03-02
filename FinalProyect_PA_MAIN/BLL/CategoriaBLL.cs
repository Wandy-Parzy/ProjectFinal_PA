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

namespace ProyectoFinal.BLL // BLL Para la categoria del articulo
{
    public class CategoriaBLL
    {
        private ApplicationDbContext contexto;

        public CategoriaBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        public Categoria Buscar(int id)
        {
            Categoria categoria = new Categoria();

            try
            {
                categoria = contexto.Categoria
                .Where(p => p.CategoriaId == id && p.Estado == true)
                .AsNoTracking()
                .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }


        public List<Categoria> GetList(Expression<Func<Categoria, bool>> categoria)
        {
            List<Categoria> Lista = new List<Categoria>();
            try
            {
                Lista = contexto.Categoria
                .Where(c => c.Estado == true)
                .Where(categoria)
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
