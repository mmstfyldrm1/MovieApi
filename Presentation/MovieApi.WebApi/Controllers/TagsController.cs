using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Command.CastCommand;
using MovieApi.Application.Features.MediatorDesignPattern.Command.TagCommand;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTagsList()
        {
            try
            {
                var values = await _mediator.Send(new GetTagQueries());
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTags(CreateTagCommand command)
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

        [HttpPut]
        public async Task<IActionResult> UpdateTags(UpdateTagCommand command)
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

        [HttpDelete]
        public async Task<IActionResult> DeleteTags(int id)
        {
            try
            {
                await _mediator.Send(new RemoveTagCommand(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var values = await _mediator.Send(new GetTagByIdQueries(id));
                return Ok(values);
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}");
            }
        }
    }
}
