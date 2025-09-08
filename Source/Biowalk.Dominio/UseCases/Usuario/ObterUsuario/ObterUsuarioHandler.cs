using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.ProcessaEtapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Usuario.ObterUsuario
{
    public class ObterUsuarioHandler : IRequestHandler<ObterUsuarioCommand, Response<ObterUsuarioResult>>
    {
        private IUnitOfWork _unitOfWork;
        public ObterUsuarioHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ObterUsuarioResult>> Handle(ObterUsuarioCommand request)
        {
            var response = new Response<ObterUsuarioResult>();

            var resultado = await _unitOfWork.UsuarioRepository.ObterPorLoginSenha(request.LoginUsuario, request.SenhaUsuario);

            if (resultado == null)
            {
                response.AddErro("Usuario não encontrado");
                return response;
            }

            response.AddValue(new ObterUsuarioResult(resultado.IdSetor.ToString()));

            return response;
        }
    }
}
