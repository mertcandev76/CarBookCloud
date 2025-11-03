using CarBookCloud.Contracts.Commands;
using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookCloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarPricingCreateDto dto)
            => Ok(await _mediator.Send(new CreateCarPricingCommand(dto)));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CarPricingUpdateDto dto)
            => Ok(await _mediator.Send(new UpdateCarPricingCommand(dto)));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCarPricingCommand(id));
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCarPricingByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllCarPricingsQuery()));
    }
}
