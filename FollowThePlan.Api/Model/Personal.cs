using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Model
{
    public class Personal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;
        public string Celular { get; set; }
        public string Cref { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime? Updated_at { get; set; } = null;
        public string UrlHash { get; set; } = null;
        public DateTime? ValidadeHash { get; set; } = null;
        public int IdCidade { get; set; } = 0;

        public IEnumerable<PersonalCliente> PersonalClientes { get; set; }

        public Personal()
        {

        }

        public Personal(int id, string nome, string email, string senha, DateTime dataNascimento, bool ativo, string celular, string cref, DateTime created_at, DateTime? updated_at, string urlHash, DateTime? validadeHash, int idCidade)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
            Ativo = ativo;
            Celular = celular;
            Cref = cref;
            Created_at = created_at;
            Updated_at = updated_at;
            UrlHash = urlHash;
            ValidadeHash = validadeHash;
            IdCidade = idCidade;
        }
    }
}
