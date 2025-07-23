using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Equipamentos.AlteraEquipamento
{
    public class AlteraEquipamentoCommand : IRequest<Response<AlteraEquipamentoResult>>
    {
        public Guid IdEquipamento{ get; set; }
        public string Nome { get; set; }
    }
}
