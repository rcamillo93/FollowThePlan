using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Model
{
    public class Alimento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Porcao { get; set; } = 100;
        public double Carboidrato { get; set; }
        public double Proteina { get; set; }
        public double Gordura { get; set; }

        public Alimento()
        {

        }

        public Alimento(int id, string descricao, double porcao, double carboidrato, double proteina, double gordura)
        {
            Id = id;
            Descricao = descricao;
            Porcao = porcao;
            Carboidrato = carboidrato;
            Proteina = proteina;
            Gordura = gordura;
        }
    }
}
