using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente(CriaClienteCommand request)
        {
            IdCliente = Guid.NewGuid(); 

            RazaoSocial = request.RazaoSocial;
            NomeFantasia = request.NomeFantasia;
            UF = request.UF;
            Logradouro = request.Logradouro;
            CEP = request.CEP; 
            Bairro = request.Bairro; 
            Cidade = request.Cidade; 
            NomeSocio = request.NomeSocio; 

            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public Cliente() { }

        public Guid IdCliente { get; set; } // uniqueidentifier
        public string RazaoSocial { get; set; } // varchar(100)
        public string NomeFantasia { get; set; } // varchar(100)
        public DateTime DataCriacao { get; set; } // datetime
        public DateTime DataAlteracao { get; set; } // datetime
        public string NomeSocio { get; set; } // varchar(100)
        public string Logradouro { get; set; } // varchar(100)
        public string CEP { get; set; } // varchar(11)
        public string Bairro { get; set; } // varchar(50)
        public string Cidade { get; set; } // varchar(50)
        public string UF { get; set; } // varchar(50)
    }
}
