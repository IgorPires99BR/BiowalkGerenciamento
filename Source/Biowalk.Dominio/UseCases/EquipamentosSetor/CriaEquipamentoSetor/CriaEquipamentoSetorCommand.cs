using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.EquipamentosSetor.CriaEquipamentoSetor
{
    public class CriaEquipamentoSetorCommand : IRequest<Response<CriaEquipamentoSetorResult>>
    {
        public Guid IdSetor { get; set; }
        public Guid IdEquipamento { get; set; }
    }
}
