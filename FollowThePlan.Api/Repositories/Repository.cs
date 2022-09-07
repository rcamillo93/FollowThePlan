using FollowThePlan.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Repositories
{
    public class Repository : IRepository
    {
        private readonly Context _context;
        public Repository(Context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                _context.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            try
            {
                return (_context.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
