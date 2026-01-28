using Microsoft.AspNetCore.Mvc;
using MovieApi.DTO.Dtos.MovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
	public class MovieController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MovieList()
		{
			try
			{
				var client = _httpClientFactory.CreateClient();
				var ResponseMessage = await client.GetAsync("https://localhost:7240/api/Movies");
				
				if(ResponseMessage.IsSuccessStatusCode) 
				{
					var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
					var values= JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
					return View(values);
				}
			}
			catch (Exception ex)
			{

                return View(ex.Message);
            }
			return View(null);
			
		}
	}
}
