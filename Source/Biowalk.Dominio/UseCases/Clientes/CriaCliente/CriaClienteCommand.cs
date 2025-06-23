using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.CriaCliente
{
    public class CriaClienteCommand : IRequest<Response<CriaClienteResult>>
    {
        public Guid IdCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Estado { get; set; }
    }
}
