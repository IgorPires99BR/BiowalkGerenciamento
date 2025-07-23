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

namespace Biowalk.Dominio.UseCases.Equipamentos.DeletaEquipamento
{
    public class DeletaEquipamentoHandler : IRequestHandler<DeletaEquipamentoCommand, Response<DeletaEquipamentoResult>>
    {
        private IUnitOfWork _unitOfWork;
        public DeletaEquipamentoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<DeletaEquipamentoResult>> Handle(DeletaEquipamentoCommand request)
        {
            var response = new Response<DeletaEquipamentoResult>();

            var validator = new DeletaEquipamentoValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            var equipamentoBanco = await _unitOfWork.EquipamentoRepository.Deletar(request.IdEquipamento);

            if (equipamentoBanco == null)
            {
                response.AddErro("Erro ao deletar Equipamento no banco de dados");
                return response;
            }

            return response;
        }
    }
}
