using FollowThePlan.Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Data
{
    public class Context : DbContext
    {
        public DbSet<Personal> Personais { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Refeicao> Refeicoes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

    }
}
