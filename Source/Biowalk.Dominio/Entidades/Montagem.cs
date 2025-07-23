using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class Montagem
    {
        public Guid IdMontagem  { get; set; }

        public Guid IdEquipamento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataMontagem { get; set; }
    }
}
