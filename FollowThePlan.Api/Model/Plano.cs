using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Model
{
    public class Plano
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
        public int IdPersonal { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public int IdStatus { get; set; }

        public Plano()
        {
                
        }

        public Plano(int id, string titulo, string descricao, int idCliente, int idPersonal, DateTime dataInicial, DateTime dataFinal, int idStatus)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            IdCliente = idCliente;
            IdPersonal = idPersonal;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            IdStatus = idStatus;
        }
    }
}
