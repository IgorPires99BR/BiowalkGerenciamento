using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.AlteraCliente
{
    public class AlteraClienteCommand : IRequest<Response<AlteraClienteResult>>
    {
        public Guid IdCliente { get; set; }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string NomeSocio { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
