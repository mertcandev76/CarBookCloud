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
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarCreateDto dto)
            => Ok(await _mediator.Send(new CreateCarCommand(dto)));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarDto dto)
            => Ok(await _mediator.Send(new UpdateCarCommand(dto)));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCarCommand(id));
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllCarsQuery()));
    }
}
