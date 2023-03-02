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

namespace ProyectoFinal.BLL // BLL Para el metodo de pago
{
    public class PagoBLL
    {
        private ApplicationDbContext contexto;

        public PagoBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        public async Task<Pago> Buscar(int id)
        {
            Pago pago = new Pago();

            try
            {
                pago = await contexto.Pago.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }


        public List<Pago> GetList(Expression<Func<Pago, bool>> pago)
        {
            List<Pago> Lista = new List<Pago>();
            try
            {
                Lista = contexto.Pago
                .Where(p => p.Estado == true)
                .Where(pago)
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
