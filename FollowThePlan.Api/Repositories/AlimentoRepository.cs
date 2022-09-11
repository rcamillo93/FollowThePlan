using FollowThePlan.Api.Data;
using FollowThePlan.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Repositories
{
    public interface IAlimentoRepository
    {
        Alimento GetAlimentoById(int planoId);
        Alimento GetAlimentoByName(string name);
    }

    public class AlimentoRepository : IAlimentoRepository
    {
        private readonly Context _context;

        public AlimentoRepository(Context context)
        {
            _context = context;
        }

        public Alimento GetAlimentoById(int alimentoId)
        {
            IQueryable<Alimento> query = _context.Alimentos;

            query = query.AsNoTracking()
             .Where(alimento => alimento.Id == alimentoId)
             .OrderBy(p => p.Id);

            return query.FirstOrDefault();
        }

        public Alimento GetAlimentoByName(string name)
        {
            IQueryable<Alimento> query = _context.Alimentos;

            query = query.AsNoTracking()
             .Where(alimento => alimento.Descricao == name)
             .OrderBy(p => p.Id);

            return query.FirstOrDefault();
        }
    }
}