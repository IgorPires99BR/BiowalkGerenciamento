using Biowalk.Dominio.Common;
using Biowalk.Dominio.Help.Error;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.DeletaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.ObterTodos
{
    public class ObterTodosClientesHandler : IRequestHandler<ObterTodosClientesCommand, Response<List<ObterTodosClientesResult>>>
    {
        private IUnitOfWork _unitOfWork;
        public ObterTodosClientesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ObterTodosClientesResult>>> Handle(ObterTodosClientesCommand request)
        {
            var response = new Response<List<ObterTodosClientesResult>>();

            var validator = new ObterTodosClientesValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            var clienteBanco = await _unitOfWork.ClienteRepository.ObterTodos();

            if (clienteBanco == null)
            {
                response.AddErro("Erro ao Obter Clientes no banco de dados");
                return response;
            }

            var results = clienteBanco?.Select(c => new ObterTodosClientesResult
            {
                IdCliente = c.IdCliente,
                RazaoSocial = c.RazaoSocial,
                NomeFantasia = c.NomeFantasia,
                Bairro = c.Bairro,
                CEP = c.CEP,
                Cidade = c.Cidade,
                Logradouro = c.Logradouro,
                NomeSocio = c.NomeSocio,
                UF = c.UF
            }).ToList();

            response.AddValue(results);

            return response;
        }
    }
}
