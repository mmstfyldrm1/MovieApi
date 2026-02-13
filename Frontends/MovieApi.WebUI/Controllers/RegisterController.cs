using Microsoft.AspNetCore.Mvc;
using MovieApi.DTO.Dtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MovieApi.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateRegisterDto _createRegisterDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(_createRegisterDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7240/api/Register", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                ViewBag.error = "Kayıt başarısız oldu lütfen tekrar deneyiniz!";
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
       
            return RedirectToAction("SingIn", "Login");
        }
    }
}
