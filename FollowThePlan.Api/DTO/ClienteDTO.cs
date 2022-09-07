using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Basal { get; set; }
        public int Nivel { get; set; }
        public double GastoAtividades { get; set; }
        public DateTime Created_at { get; set; }
        public int Idade { get; set; }
        public string Celular { get; set; }
    }
}
