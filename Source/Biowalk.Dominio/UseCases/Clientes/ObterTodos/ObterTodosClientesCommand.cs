using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.ObterTodos
{
    public class ObterTodosClientesCommand : IRequest<Response<List<ObterTodosClientesResult>>>
    {

    }
}
