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

namespace StudentManagement.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string BaseUrl = "https://localhost:5001/api/";

        public IActionResult Index()
        {
            IEnumerable<Student> students = new List<Student>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("students").Result;

                if (response.IsSuccessStatusCode)
                {
                    students = JsonConvert.DeserializeObject<IList<Student>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            
            return View(students);
        } 

        public IActionResult Create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
            }

                return View();
        }
    }
}
