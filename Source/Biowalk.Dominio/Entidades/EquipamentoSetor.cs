using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class EquipamentoSetor
    {
        public Guid IdEquipamentoSetor { get; set; }
        public Guid IdSetor { get; set; }
        public Guid IdEquipamento { get; set; }
    }
}
