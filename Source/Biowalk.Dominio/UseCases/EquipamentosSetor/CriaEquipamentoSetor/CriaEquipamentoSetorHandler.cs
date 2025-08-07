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

namespace Biowalk.Dominio.UseCases.EquipamentosSetor.CriaEquipamentoSetor
{
    public class CriaEquipamentoSetorHandler : IRequestHandler<CriaEquipamentoSetorCommand, Response<CriaEquipamentoSetorResult>>
    {
        private IUnitOfWork _unitOfWork;
        public CriaEquipamentoSetorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<CriaEquipamentoSetorResult>> Handle(CriaEquipamentoSetorCommand request)
        {
            var response = new Response<CriaEquipamentoSetorResult>();

            var validator = new CriaEquipamentoSetorValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            EquipamentoSetor equipamentoSetor = new EquipamentoSetor()
            {
                IdEquipamentoSetor = Guid.NewGuid(),
                IdSetor = request.IdSetor,
                IdEquipamento = request.IdEquipamento
            };

            var resultado = _unitOfWork.EquipamentoSetorRepository.Adicionar(equipamentoSetor);

            if (resultado == null)
            {
                response.AddErro("Erro ao Salvar Relação Equipamento Setor");
                throw new Exception();
            }

            response.AddValue(new CriaEquipamentoSetorResult("Salvo com sucesso"));

            return response;
        }
    }
}
