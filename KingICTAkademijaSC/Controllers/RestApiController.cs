using KingICTAkademijaSC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KingICTAkademijaSC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public RestApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "https://dummyjson.com/products";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }

            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var url = "https://dummyjson.com/products/" + id;
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }

            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("search/{naziv}")]
        public async Task<IActionResult> Get(string naziv)
        {
            var url = "https://dummyjson.com/products/search?q=" + naziv;
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }

            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Get(string category, double value, bool higher)
        {
            var url = "https://dummyjson.com/products";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var JSONData = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(JSONData);

                root.Proizvodi = root.Proizvodi
                    .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
                                (higher ? p.Price > value : p.Price < value))
                    .ToList();

                string filteredJsonData = JsonConvert.SerializeObject(root, Formatting.Indented);
                return Ok(filteredJsonData);
            }

            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
}


 