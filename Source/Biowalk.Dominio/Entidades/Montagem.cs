using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class Montagem
    {
        public Guid idMontagem  { get; set; }

        public Guid idEquipamento { get; set; }

        public string descricao { get; set; }

        public DateTime dataMontagem { get; set; }
    }
}
