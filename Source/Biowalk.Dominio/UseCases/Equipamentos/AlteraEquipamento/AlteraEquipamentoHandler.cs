using Biowalk.Dominio.Common;
using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Help.Error;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Equipamentos.CriaEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Equipamentos.AlteraEquipamento
{
    public class AlteraEquipamentoHandler : IRequestHandler<AlteraEquipamentoCommand, Response<AlteraEquipamentoResult>>
    {
        private IUnitOfWork _unitOfWork;
        public AlteraEquipamentoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<AlteraEquipamentoResult>> Handle(AlteraEquipamentoCommand request)
        {
            var response = new Response<AlteraEquipamentoResult>();

            var validator = new AlteraEquipamentoValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            Equipamento equipamento = new Equipamento()
            {
                IdEquipamento = request.IdEquipamento,
                Nome = request.Nome,
            };

            var resultado = await _unitOfWork.EquipamentoRepository.Atualizar(equipamento);

            if(resultado == 0)
            {
                response.AddErro("Erro ao salvar Equipamento no banco de dados");
                return response;
            }

            return response;
        }
    }
}
