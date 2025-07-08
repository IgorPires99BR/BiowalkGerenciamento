using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Clientes.AlteraCliente;
using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using Biowalk.Dominio.UseCases.Clientes.DeletaCliente;
using Biowalk.Dominio.UseCases.Clientes.ObterTodos;
using Biowalk.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biowalk.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        public IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CriaClienteCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created,response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraClienteCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletaClienteCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ObterTodosClientesCommand());
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }
    }
}
