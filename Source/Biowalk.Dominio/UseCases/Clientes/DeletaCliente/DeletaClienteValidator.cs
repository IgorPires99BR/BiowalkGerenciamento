using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.DeletaCliente
{
    public class DeletaClienteValidator : AbstractValidator<DeletaClienteCommand>
    {
        public DeletaClienteValidator()
        {
            RuleFor(x => x.IdCliente).NotEmpty().WithMessage("IdCliente é um campo Obrigatório");
        }
    }
}
