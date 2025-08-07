using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.Equipamentos.CriaEquipamento;
using Biowalk.Dominio.UseCases.EquipamentosSetor.CriaEquipamentoSetor;
using Biowalk.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biowalk.WebAPI.Controllers.V1.EquipamentosSetor
{
    [ApiController]
    [Route("[controller]")]
    public class EquipamentosSetorController : Controller
    {
        public IMediator _mediator;

        public EquipamentosSetorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CriaEquipamentoSetorCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }
    }
}
