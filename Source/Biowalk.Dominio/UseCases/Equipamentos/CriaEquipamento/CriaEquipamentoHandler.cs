using Biowalk.Dominio.Common;
using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Help.Error;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Equipamentos.CriaEquipamento
{
    public class CriaEquipamentoHandler : IRequestHandler<CriaEquipamentoCommand, Response<CriaEquipamentoResult>>
    {

        private IUnitOfWork _unitOfWork;
        public CriaEquipamentoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CriaEquipamentoResult>> Handle(CriaEquipamentoCommand request)
        {
            var response = new Response<CriaEquipamentoResult>();

            var validator = new CriaEquipamentoValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            Equipamento equipamento = new Equipamento()
            {
                IdEquipamento = Guid.NewGuid(),
                Nome = request.Nome
            };

            var equipamentoBanco = await _unitOfWork.EquipamentoRepository.Incluir(equipamento);

            if (equipamentoBanco == null)
            {
                response.AddErro("Erro ao salvar Equipamento no banco de dados");
                return response;
            }

            return response;
        }
    }
}
