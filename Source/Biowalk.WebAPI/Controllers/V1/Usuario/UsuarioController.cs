using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Usuario.ObterUsuario;
using Biowalk.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biowalk.WebAPI.Controllers.V1.Usuario
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        public IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post(ObterUsuarioCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }
    }
}
