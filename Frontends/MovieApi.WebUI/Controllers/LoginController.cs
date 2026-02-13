using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> SingIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingIn(int x)
        {
            return View();
        }
    }
}
