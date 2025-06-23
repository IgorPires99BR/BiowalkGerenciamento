using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Estado { get; set; }
    }
}
