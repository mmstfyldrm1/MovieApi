using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommand;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterCommandHandler;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _createUserRegisterCommandHandler;

        public RegisterController(CreateUserRegisterCommandHandler createUserRegisterCommandHandler)
        {
            _createUserRegisterCommandHandler = createUserRegisterCommandHandler;
        }
        [HttpPost]

        public async Task<IActionResult> CreateUser(CreateUserRegisterCommand command)
        {
            try
            {
                await _createUserRegisterCommandHandler.Handle(command);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }
}
