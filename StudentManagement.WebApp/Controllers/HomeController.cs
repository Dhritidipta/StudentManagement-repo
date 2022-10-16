using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagement.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace StudentManagement.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index(string orderBy, string currentFilter, string searchName, int? pageNum)
        {
            var accessToken = HttpContext.Session.GetString("Token");
            ViewData["CurrentSort"] = orderBy;
            ViewData["NameSortParam"] = orderBy == "Name_asc" ? "Name_desc" : "Name_asc";
            ViewData["DateSortParam"] = orderBy == "Date" ? "Date_desc" : "Date";

            if(searchName != null)
            {
                pageNum = 1;
            }
            else
            {
                searchName = currentFilter;
            }

            ViewData["CurrentFilter"] = searchName;

            int pageNumber = pageNum ?? 1;
            int pageSize = 7;
            Metadata responseHeaderPagerData;
            IEnumerable<StudentDetails> students = new List<StudentDetails>();

            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(_config["BaseUrl"]);
                var response = client.GetAsync($"students?PageNumber={pageNumber}&PageSize={pageSize}&OrderBy={orderBy}&SearchName={searchName}").Result;
                responseHeaderPagerData = JsonConvert.DeserializeObject<Metadata>(response.Headers.GetValues("X-Pagination").FirstOrDefault());
                if (response.IsSuccessStatusCode)
                {
                    students = JsonConvert.DeserializeObject<IList<StudentDetails>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            ViewBag.PagerData = responseHeaderPagerData;
            
            return View(students);
        }
        
       
    }
}
