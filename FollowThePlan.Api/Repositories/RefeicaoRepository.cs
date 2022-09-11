using FollowThePlan.Api.Data;
using FollowThePlan.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Repositories
{
    public interface IRefeicaoRepository
    {
        Refeicao GetRefeicaoById(int refeicaoId);  
    }

    public class RefeicaoRepository : IRefeicaoRepository
    {
        private readonly Context _context;

        public RefeicaoRepository(Context context)
        {
            _context = context;
        }

        public Refeicao GetRefeicaoById(int refeicaoId)
        {
            IQueryable<Refeicao> query = _context.Refeicoes;

            query = query.AsNoTracking()
             .Where(refeicao => refeicao.Id == refeicaoId)
             .OrderBy(r => r.Id);

            return query.FirstOrDefault();
        }
    }
}