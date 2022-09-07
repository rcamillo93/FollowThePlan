using FollowThePlan.Api.Data;
using FollowThePlan.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Repositories
{
    public interface IObjetivoRepository
    {
        //  Objetivo[] GetAll(int userId);
        Objetivo GetObjetivoById(int objetivoId);

    }

    public class ObjetivoRepository : IObjetivoRepository
    {
        private readonly Context _context;

        public ObjetivoRepository(Context context)
        {
            _context = context;
        }

        public Objetivo GetObjetivoById(int objetivoId)
        {
            IQueryable<Objetivo> query = _context.Objetivos;

            query = query.AsNoTracking()
             .Where(objetivo => objetivo.IdCliente == objetivoId)
             .OrderBy(o => o.Id);

            return query.FirstOrDefault();
        }
    }
}