using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.DTO
{
    public class PersonalRegisterDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; } = true;
        public string Celular { get; set; }
        public string Cref { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime DataNascimento { get; set; }

    }
}
