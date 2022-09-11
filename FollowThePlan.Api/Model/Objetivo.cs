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
        public DateTime? DataFinal { get; set; }
        public double PesoAtual { get; set; }
        public double PesoFinal { get; set; }
        public double PesoAlvo { get; set; }
        public double BodyFatAtual { get; set; }
        public double BodyFatAlvo { get; set; }
        public int IdStatus { get; set; }
        public int IdCliente { get; set; }
        public int IdPersonal { get; set; }

        public Objetivo()
        {

        }

        public Objetivo(int id, string titulo, string descricao, DateTime created_at, DateTime dataInicial, DateTime dataFinal, double pesoAtual, double pesoFinal, double pesoAlvo, double bodyFatAtual, double bodyFatAlvo, int idStatus, int idCliente, int idPersonal)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Created_at = created_at;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            PesoAtual = pesoAtual;
            PesoFinal = pesoFinal;
            PesoAlvo = pesoAlvo;
            BodyFatAtual = bodyFatAtual;
            BodyFatAlvo = bodyFatAlvo;
            IdStatus = idStatus;
            IdCliente = idCliente;
            IdPersonal = idPersonal;
        }
    }
}
