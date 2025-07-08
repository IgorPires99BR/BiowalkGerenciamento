using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.AlteraCliente
{
    public class AlteraClienteValidator : AbstractValidator<AlteraClienteCommand>
    {
        public AlteraClienteValidator()
        {


        }
    }
}
