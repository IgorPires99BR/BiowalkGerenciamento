using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.ObterEquipamentoMontagem
{
    public class ObterEquipamentoMontagemHandler : IRequestHandler<ObterEquipamentoMontagemQuery, Response<List<ObterEquipamentoMontagemResult>>>
    {
        private IUnitOfWork _unitOfWork;
        public ObterEquipamentoMontagemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<List<ObterEquipamentoMontagemResult>>> Handle(ObterEquipamentoMontagemQuery request)
        {
            var response = new Response<List<ObterEquipamentoMontagemResult>>();
            var listaEquipamentos = new List<ObterEquipamentoMontagemResult>();

            var resultado = await _unitOfWork.EquipamentoMontagemRepository.ObterTodos();

            if (resultado != null)
            {
                foreach (var queryAdapters in resultado)
                {
                    listaEquipamentos.Add(new ObterEquipamentoMontagemResult
                    {
                        IdEquipamentoMontagem = queryAdapters.IdEquipamentoMontagem,
                        NomeSetor = queryAdapters.NomeSetor,
                        NomeEquipamento = queryAdapters.NomeEquipamento,
                        DataLancamento = queryAdapters.DataLancamento,
                        DataFechamentoCorte = queryAdapters.DataFechamentoCorte,
                        DataFechamentoSolda = queryAdapters.DataFechamentoSolda,
                        DataFechamentoMontagem = queryAdapters.DataFechamentoMontagem,
                        DataFechamentoPintura = queryAdapters.DataFechamentoPintura,
                        Status = queryAdapters.Status,
                        Etapa = queryAdapters.Etapa
                    });
                }

                response.AddValue(listaEquipamentos);
            }

            return response;
        }
    }
}
