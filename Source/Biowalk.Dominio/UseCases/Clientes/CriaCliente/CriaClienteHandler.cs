using Biowalk.Dominio.Common;
using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Help.Error;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.CriaCliente
{
    public class CriaClienteHandler : IRequestHandler<CriaClienteCommand, Response<CriaClienteResult>>
    {
        private IUnitOfWork _unitOfWork;
        public CriaClienteHandler(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CriaClienteResult>> Handle(CriaClienteCommand request)
        {
            var response = new Response<CriaClienteResult>();

            var validator = new CriaClienteValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            Cliente cliente = new Cliente(request);

            var clienteBanco = await _unitOfWork.ClienteRepository.Incluir(cliente);

            if (clienteBanco == null)
            {
                response.AddErro("Erro ao salvar Cliente no banco de dados");
                return response;
            }
                
            return response;

        }
    }
}
