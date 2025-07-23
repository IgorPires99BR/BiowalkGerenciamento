using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.AlteraCliente;
using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using Biowalk.Dominio.UseCases.Clientes.DeletaCliente;
using Biowalk.Dominio.UseCases.Clientes.ObterTodos;
using Biowalk.Dominio.UseCases.Equipamentos.AlteraEquipamento;
using Biowalk.Dominio.UseCases.Equipamentos.CriaEquipamento;
using Biowalk.Dominio.UseCases.Equipamentos.DeletaEquipamento;
using Biowalk.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biowalk.WebAPI.Controllers.V1.Equipamentos
{
    [ApiController]
    [Route("[controller]")]
    public class EquipamentosController : ControllerBase
    {
        public IMediator _mediator;

        public EquipamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CriaEquipamentoCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraEquipamentoCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletaEquipamentoCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }
    }
}
