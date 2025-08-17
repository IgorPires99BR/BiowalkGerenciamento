using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.ProcessaEtapa
{
    public class ProcessaEtapaCommand : IRequest<Response<ProcessaEtapaResult>>
    {
        public string IdEquipamentoMontagem { get; set; }
        public int EtapaAtual { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
