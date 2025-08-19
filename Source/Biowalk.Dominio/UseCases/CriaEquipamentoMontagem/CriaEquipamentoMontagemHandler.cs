using Biowalk.Dominio.Common;
using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.ObterEquipamentoMontagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.CriaEquipamentoMontagem
{
    public class CriaEquipamentoMontagemHandler : IRequestHandler<CriaEquipamentoMontagemCommand, Response<CriaEquipamentoMontagemResult>>
    {
        private IUnitOfWork _unitOfWork;
        public CriaEquipamentoMontagemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CriaEquipamentoMontagemResult>> Handle(CriaEquipamentoMontagemCommand request)
        {
            var response = new Response<CriaEquipamentoMontagemResult>();


            EquipamentoMontagem montagem = new EquipamentoMontagem()
            {
                IdEquipamentoMontagem = Guid.NewGuid(),
                IdEquipamento = Guid.Parse(request.IdEquipamento),
                DataLancamento = DateTime.Now,
                DataFechamentoCorte = null,
                DataFechamentoSolda = null,
                DataFechamentoPintura = null,
                DataFechamentoMontagem = null,
                Status = 1,
                Etapa = 1
            };


            var resultado = await _unitOfWork.EquipamentoMontagemRepository.Adicionar(montagem);

            return response;
        }
    }
}
