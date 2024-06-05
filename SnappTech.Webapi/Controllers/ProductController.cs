using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnappTech.Application.Dto.Product.Command.Add;
using SnappTech.Application.Dto.Product.Command.IncreaseInventory;
using SnappTech.Application.Dto.Product.Query;

namespace snap_tech_project.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetById")]
        public Task<GetByIdResult> GetById([FromQuery] GetByIdQuery query)
        {
            return _mediator.Send(query);
        }

        [HttpPut("CreateProduct")]
        public Task<CreateProductResult> CreateProduct(CreateProductCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPost("IncreaseInventory")]
        public Task<IncreaseInventoryResult> IncreaseInventory(IncreaseInventoryCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
