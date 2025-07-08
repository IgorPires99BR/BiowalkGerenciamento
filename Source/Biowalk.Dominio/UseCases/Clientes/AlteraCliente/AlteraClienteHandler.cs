using Biowalk.Dominio.Common;
using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Help.Error;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Clientes.AlteraCliente
{
    public class AlteraClienteHandler : IRequestHandler<AlteraClienteCommand, Response<AlteraClienteResult>>
    {
        private IUnitOfWork _unitOfWork;
        public AlteraClienteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<AlteraClienteResult>> Handle(AlteraClienteCommand request)
        {
            var response = new Response<AlteraClienteResult>();

            var validator = new AlteraClienteValidator();
            var validateResult = validator.Validate(request);

            if (!validateResult.IsValid)
            {
                response.AddErros(validateResult.Errors.ToCustomValidationFailure());
                return response;
            }

            Cliente cliente = new Cliente() 
            { 
                IdCliente = request.IdCliente,
                NomeFantasia = request.NomeFantasia,
                RazaoSocial = request.RazaoSocial,
                UF = request.UF,
                Logradouro = request.Logradouro,
                CEP = request.CEP,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                NomeSocio = request.NomeSocio,
                DataAlteracao = DateTime.Now,
        };

            var clienteBanco = await _unitOfWork.ClienteRepository.Atualizar(cliente);

            if (clienteBanco == null)
            {
                response.AddErro("Erro ao Atualizar Cliente no banco de dados");
                return response;
            }

            return response;
        }
    }
}
