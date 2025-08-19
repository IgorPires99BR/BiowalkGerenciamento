using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.ObterEquipamentoMontagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.ProcessaEtapa
{
    public class ProcessaEtapaHandler : IRequestHandler<ProcessaEtapaCommand, Response<ProcessaEtapaResult>>
    {

        private IUnitOfWork _unitOfWork;
        public ProcessaEtapaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        //Método responsável por fazer a geração das proximas etapas, ele faz a clicagem dos quadros no front-end
        public async Task<Response<ProcessaEtapaResult>> Handle(ProcessaEtapaCommand request)
        {
            var response = new Response<ProcessaEtapaResult>();

            var resultado = await _unitOfWork.EquipamentoMontagemRepository.ProcessaEtapa(request.IdEquipamentoMontagem, request.EtapaAtual, request.DataAtualizacao);

            if (resultado == 0)
            {
                response.AddErro("Erro ao atualizar Etapa");
                return response;
            }

            response.AddValue(new ProcessaEtapaResult("OK"));

            return response;
        }
    }
}
