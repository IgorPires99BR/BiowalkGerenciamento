using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Equipamentos.CriaEquipamento
{
    public class CriaEquipamentoCommand : IRequest<Response<CriaEquipamentoResult>>
    {
        public string Nome { get; set; }
    }
}
