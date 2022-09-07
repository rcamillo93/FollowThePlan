using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.DTO
{
    public class ClienteRegisterDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public double Peso { get; set; }
        public bool Ativo { get; set; } = true;
        public double Altura { get; set; }
        public double GastoAtividades { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public int Nivel { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
    }
}
