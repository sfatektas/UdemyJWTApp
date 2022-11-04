using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Text.Json;
using UdemyJWTApp.Front.Models;

namespace UdemyJWTApp.Front.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5249/api/Products");
            var jsonData = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<ProductListModel>>(jsonData, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            return View(data);
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5249/api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            return NotFound("Bu idye ait veri bulunamadı");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "Token").Value;

            //add token to request header 
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("http://localhost:5249/api/Categories");
            var jsonData = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var model = new ProductCreateModel();

            model.CategorySelectList = new SelectList(data,"Id","Description");
            return View(model);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var token = User.Claims.SingleOrDefault(x => x.Type == "Token").Value;
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var stringdata = JsonSerializer.Serialize(model);
                StringContent stringcontent = new StringContent(stringdata);
                var response = await client.PostAsync("http://localhost:5249/api/Categories", stringcontent);
            }


            return RedirectToAction("List");
        }
    }
}
