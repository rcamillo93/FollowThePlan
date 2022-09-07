using FollowThePlan.Api.Data;
using FollowThePlan.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Repositories
{
    public interface IPersonalRepository
    {
        Personal[] GetAll();
        Personal GetById(int personalId);
    }

    public class PersonalRepository : IPersonalRepository
    {
        private readonly Context _context;

        public PersonalRepository(Context context)
        {
            _context = context;
        }

        public Personal[] GetAll()
        {
            IQueryable<Personal> query = _context.Personais;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Personal GetById(int personalId)
        {
            IQueryable<Personal> query = _context.Personais;

            query = query.AsNoTracking()
             .Where(personal => personal.Id == personalId)
             .OrderBy(p => p.Id);

            return query.FirstOrDefault();
        }
    }
}
