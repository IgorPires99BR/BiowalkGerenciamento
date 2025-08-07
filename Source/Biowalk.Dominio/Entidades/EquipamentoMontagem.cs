using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class EquipamentoMontagem
    {
        public Guid IdEquipamentoMontagem { get; set; }
        public Guid IdSetor { get; set; }
        public Guid IdEquipamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public int status { get; set; }
    }
}
