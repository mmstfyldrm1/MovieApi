using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Command.CastCommand;
using MovieApi.Application.Features.MediatorDesignPattern.Queries;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCast()
        {
            try
            {
                var values = await _mediator.Send(new GetCastQuery());
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand castCommand)
        {
            try
            {
                await _mediator.Send(castCommand);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id)
        {
            try
            {
                await _mediator.Send(new RemoveCastCommand(id));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetCastById(int id)
        {
            try
            {
                var values =await _mediator.Send(new GetCastQueryById(id));
                return Ok(values);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }
    }
}
