using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.WebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.WebApp.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace StudentManagement.WebApp.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {

        private readonly string BaseUrl;
        public StudentController(IConfiguration config)
        {
            BaseUrl = config["BaseUrl"];
        }

    public IActionResult Details(int id)
        {
            var accessToken = HttpContext.Session.GetString("Token");
            IEnumerable<StudentDetails> students = new List<StudentDetails>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync($"students/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    students = JsonConvert.DeserializeObject<IList<StudentDetails>>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return View(students.SingleOrDefault());
        }

        public IActionResult Create()
        {
            //var courses = GetDetailsUtility.GetCoursesList();

            //List<SelectListItem> courseList = new List<SelectListItem>();
            //foreach (var item in courses)
            //{

            //    courseList.Add(new SelectListItem { Value = item.CourseName , Text = item.CourseName });
            //}

            //var sections = GetDetailsUtility.GetSectionsList(); ;

            //List<SelectListItem> sectionList = new List<SelectListItem>();
            //foreach (var item in sections)
            //{

            //    sectionList.Add(new SelectListItem { Value = item.SectionName, Text = item.SectionName });
            //}

            //assigning SelectListItem to view Bag
            //ViewBag.courses = courseList;
            //ViewBag.sections = sectionList;
            ViewBag.token = HttpContext.Session.GetString("Token");
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreate student)
        {
            var accessToken = HttpContext.Session.GetString("Token");
            if (ModelState.IsValid)
            {

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(BaseUrl);

                var stringContent = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("students", stringContent);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(student);
        }

        public ViewResult Edit(int id)
        {
            var accessToken = HttpContext.Session.GetString("Token");
            IEnumerable<StudentDetails> students = new List<StudentDetails>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync($"students/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    students = JsonConvert.DeserializeObject<IList<StudentDetails>>(response.Content.ReadAsStringAsync().Result);
                }
            }

            ViewBag.id = id;
            ViewBag.student = students.SingleOrDefault();
            ViewBag.token = accessToken;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(StudentUpdate student, int id)
        {
            var accessToken = HttpContext.Session.GetString("Token");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(BaseUrl);
                var stringContent = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");
                var putTask = client.PutAsync($"students/{id}", stringContent);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error.");

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var accessToken = HttpContext.Session.GetString("Token");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(BaseUrl);
                var deleteTask = client.DeleteAsync($"students/{id}");
                deleteTask.Wait();

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error.");
            //return View("Index");
            return RedirectToAction("Index", "Home");

        }
    }
}
