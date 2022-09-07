using FollowThePlan.Api.Data;
using FollowThePlan.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Repositories
{
        public interface IClienteRepository
        {
            Cliente[] GetAll();
            Cliente GetById(int personalId);
            Cliente GetBasalById(int personalId);
        }

        public class ClienteRepository : IClienteRepository
        {
            private readonly Context _context;

            public ClienteRepository(Context context)
            {
                _context = context;
            }

            public Cliente[] GetAll()
            {
                IQueryable<Cliente> query = _context.Clientes;

                query = query.AsNoTracking().OrderBy(c => c.Id);

                return query.ToArray();
            }

            public Cliente GetBasalById(int clienteId)
            {
                throw new NotImplementedException();
            }

            public Cliente GetById(int clienteId)
            {
                IQueryable<Cliente> query = _context.Clientes;

                query = query.AsNoTracking()
                 .Where(cliente => cliente.Id == clienteId)
                 .OrderBy(c => c.Id);

                return query.FirstOrDefault();
            }
        }
    }

