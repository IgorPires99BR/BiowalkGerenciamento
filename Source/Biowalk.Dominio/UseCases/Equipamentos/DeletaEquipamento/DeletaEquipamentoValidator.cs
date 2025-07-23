using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Equipamentos.DeletaEquipamento
{
    public class DeletaEquipamentoValidator : AbstractValidator<DeletaEquipamentoCommand>
    {
        public DeletaEquipamentoValidator()
        {
            
        }
    }
}
