using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentManagement.WebApp.Models;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private IHttpContextAccessor _httpContext;
        private readonly string LoginUrl;

        public LoginController(IConfiguration config, IHttpContextAccessor contextAccessor, ILogger<LoginController> logger)
        {
            _logger = logger;
            _httpContext = contextAccessor;
            LoginUrl = config["LoginUrl"];

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginUser(LoginInfo model)
        {
            using (var client = new HttpClient())
            {
                StringContent sc = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(LoginUrl, sc))
                {
                    string token = await response.Content.ReadAsStringAsync();

                    if (token == "Invalid Credentials" || token == "Invalid")
                    {
                        TempData["Message"] = "Incorrect Username Or Password";
                        return RedirectToAction("Index", "Login");
                    }

                    HttpContext.Session.SetString("Token", token);

                    var stream = token;
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(stream);
                    var tokenS = handler.ReadToken(token) as JwtSecurityToken;

                    string userr = tokenS.Claims.First(claim => claim.Type == "Username").Value;
                    HttpContext.Session.SetString("User", userr);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,userr),
                    };
                    var claimIdentity = new ClaimsIdentity(claims, "Login");
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                        IsPersistent = true,
                    };

                    await _httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                }
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _httpContext.HttpContext.SignOutAsync();
            HttpContext.Session.Remove("Token");
            HttpContext.Response.Cookies.Delete("StudentMgmt.Session");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}