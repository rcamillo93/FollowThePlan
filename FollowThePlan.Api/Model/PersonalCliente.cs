using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Model
{
    public class PersonalCliente
    {
        public Personal Personal { get; set; }
        public int IdPersonal { get; set; }
        public Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public int Status { get; set; } = 1;
        public DateTime DataContratacao { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }

        public PersonalCliente()
        {
                
        }
        public PersonalCliente(int idPersonal, int idCliente)
        {
            IdPersonal = idPersonal;
            IdCliente = idCliente;        
        }
    }
}
