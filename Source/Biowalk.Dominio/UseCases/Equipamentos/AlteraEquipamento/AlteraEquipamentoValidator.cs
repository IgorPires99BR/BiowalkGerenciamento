using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Equipamentos.AlteraEquipamento
{
    public class AlteraEquipamentoValidator : AbstractValidator<AlteraEquipamentoCommand>
    {
        public AlteraEquipamentoValidator()
        {
            
        }
    }
}
