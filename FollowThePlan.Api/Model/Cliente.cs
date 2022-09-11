using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; } = true;
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Basal { get; set; }
        public double GastoAtividades { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime? Updated_at { get; set; } = null;
        public int Nivel { get; set; } = 0;
        public DateTime DataNascimento { get; set; }
        public string UrlHash { get; set; } = null;
        public DateTime? ValidadeHash { get; set; } = null;
        public string Celular { get; set; }
        public int IdCidade { get; set; }

        public Cliente()
        {

        }
        public Cliente(int id, string nome, string email, string senha, double peso, double altura, double basal, double gastoAtividades, DateTime dataNascimento, string celular, int idCidade)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Peso = peso;
            Altura = altura;
            Basal = basal;
            GastoAtividades = gastoAtividades;
            DataNascimento = dataNascimento;
            Celular = celular;
            IdCidade = idCidade;
        }
    }
}
