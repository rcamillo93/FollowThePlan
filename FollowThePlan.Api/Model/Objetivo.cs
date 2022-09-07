using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Model
{
    public class Objetivo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public double PesoAtual { get; set; }
        public double PesoFinal { get; set; }
        public double PesoAlvo { get; set; }
        public double BodyFatAtual { get; set; }
        public double BodyFatAlvo { get; set; }
        public int IdStatus { get; set; }
        public int IdCliente { get; set; }
        public int IdPersonal { get; set; }
    }
}
