using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades.QueryAdapters
{
    public class EquipamentoMontagemQueryAdapter
    {
        public Guid IdEquipamentoMontagem { get; set; }
        public Guid IdEquipamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime? DataFechamentoCorte { get; set; }
        public DateTime? DataFechamentoSolda { get; set; }
        public DateTime? DataFechamentoPintura { get; set; }
        public DateTime? DataFechamentoMontagem { get; set; }
        public string NomeEquipamento { get; set; }
        public int Status { get; set; }
        public int Etapa { get; set; }
    }
}
