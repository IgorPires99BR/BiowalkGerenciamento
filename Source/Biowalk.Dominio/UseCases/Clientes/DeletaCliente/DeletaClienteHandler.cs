using Biowalk.Dominio.Common;
using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Help.Error;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.AlteraCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.DeletaCliente
{
    public class DeletaClienteHandler : IRequestHandler<DeletaClienteCommand, Response<DeletaClienteResult>>
    {
        private IUnitOfWork _unitOfWork;
        public DeletaClienteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<DeletaClienteResult>> Handle(DeletaClienteCommand request)
        {
            var response = new Response<DeletaClienteResult>();

            var validator = new DeletaClienteValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            var clienteBanco = await _unitOfWork.ClienteRepository.Deletar(request.IdCliente);

            if (clienteBanco == null)
            {
                response.AddErro("Erro ao Deletar Cliente no banco de dados");
                return response;
            }

            return response;
        }
    }
}
