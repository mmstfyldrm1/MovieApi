using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.LoginCommand;
using MovieApi.Persistence.Identity;


namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {

            var user1 = new AppUser { 
                Email = command.Email,
                PasswordHash = command.Password,

            };

            try
            {
                var user = await _userManager.FindByEmailAsync(user1.Email);
                if (user == null)
                    return Unauthorized("Kullanıcı bulunamadı");

                var result = await _signInManager.PasswordSignInAsync(user, user.PasswordHash, false, false);
                if (!result.Succeeded)
                    return Unauthorized("Geçersiz giriş");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
                throw;
            }






        }
    }
}
