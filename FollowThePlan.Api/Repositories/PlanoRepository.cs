using FollowThePlan.Api.Data;
using FollowThePlan.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Repositories
{
    public interface IPlanoRepository
    {      
        Plano GetPlanoById(int planoId);
    }

    public class PlanoRepository : IPlanoRepository
    {
        private readonly Context _context;

        public PlanoRepository(Context context)
        {
            _context = context;
        }

        public Plano GetPlanoById(int planoId)
        {
            IQueryable<Plano> query = _context.Planos;

            query = query.AsNoTracking()
             .Where(plano => plano.IdCliente == planoId)
             .OrderBy(p => p.Id);

            return query.FirstOrDefault();
        }
    }
}