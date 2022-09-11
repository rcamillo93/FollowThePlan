using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Model
{
    public class Refeicao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Decimal PesoTotal { get; set; }
        public decimal CarboTotal { get; set; }
        public Decimal ProteinaTotal { get; set; }
        public Decimal GordutaTotal { get; set; }
        public Decimal TotalCalorico { get; set; }
        public int IdPlano { get; set; }

        public Refeicao()
        {

        }
        public Refeicao(int id, string descricao, DateTime data, decimal pesoTotal, decimal carboTotal, decimal proteinaTotal, decimal gordutaTotal, decimal totalCalorico, int idPlano)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
            PesoTotal = pesoTotal;
            CarboTotal = carboTotal;
            ProteinaTotal = proteinaTotal;
            GordutaTotal = gordutaTotal;
            TotalCalorico = totalCalorico;
            IdPlano = idPlano;
        }
    }
}
