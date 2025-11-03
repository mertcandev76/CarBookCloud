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
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarFeaturesController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarFeatureCreateDto dto)
        {
            var result = await _mediator.Send(new CreateCarFeatureCommand(dto));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CarFeatureUpdateDto dto)
        {
            var result = await _mediator.Send(new UpdateCarFeatureCommand(dto));
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCarFeatureCommand(id));
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCarFeatureByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCarFeaturesQuery());
            return Ok(result);
        }
    }
}
