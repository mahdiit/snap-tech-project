using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnappTech.Application.Dto.Order.Command;

namespace snap_tech_project.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Buy")]
        public Task<BuyResult> Buy(BuyCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
