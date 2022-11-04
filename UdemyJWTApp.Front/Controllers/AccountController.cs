using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using UdemyJWTApp.Front.Helpers;
using UdemyJWTApp.Front.Models;

namespace UdemyJWTApp.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var requestContent = new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8,"application/json");//HttpContent nesnesini oluşturuyoruz.
                var responseMessage = await client.PostAsync("http://localhost:5249/api/Auth/SignIn",requestContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    CustomResponse customResponse = await CookieGeneratorWithToken.Generate(responseMessage);
                    
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,customResponse.Principal, customResponse.AuthenticationProperties);
                
                return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "kullanıcı adı veya şifre yanlış.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}
