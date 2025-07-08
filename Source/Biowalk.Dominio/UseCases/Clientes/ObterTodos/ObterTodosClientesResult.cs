using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.ObterTodos
{
    public class ObterTodosClientesResult
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
