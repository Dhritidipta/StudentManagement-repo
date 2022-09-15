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
            string[] courseList = { "Course-1", "Course-2", "Course-3", "Course-4" };

            List<SelectListItem> courses = new List<SelectListItem>();
            foreach (string item in courseList)
            {

                courses.Add(new SelectListItem { Value = item, Text = item });
            }

            string[] sectionList = { "A", "B", "C", "D", "E" };

            List<SelectListItem> sections = new List<SelectListItem>();
            foreach (string item in sectionList)
            {

                sections.Add(new SelectListItem { Value = item, Text = item });
            }

            //assigning SelectListItem to view Bag
            ViewBag.courses = courses;
            ViewBag.sections = sections;
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreate student)
        {   

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var stringContent = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("students", stringContent);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error.");

            return View(student);
        }

        public ViewResult Edit(int id)
        {
            string[] courseList = { "Course-1", "Course-2", "Course-3", "Course-4" };

            List<SelectListItem> courses = new List<SelectListItem>();
            foreach (string item in courseList)
            {

                courses.Add(new SelectListItem { Value = item, Text = item });
            }

            string[] sectionList = { "A", "B", "C", "D", "E" };

            List<SelectListItem> sections = new List<SelectListItem>();
            foreach (string item in sectionList)
            {

                sections.Add(new SelectListItem { Value = item, Text = item });
            }

            //assigning SelectListItem to view Bag
            ViewBag.courses = courses;
            ViewBag.sections = sections;

            ViewBag.id = id;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(StudentUpdate student, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var stringContent = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");
                var putTask = client.PutAsync($"students/{id}", stringContent);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error.");

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var deleteTask = client.DeleteAsync($"students/{id}");
                deleteTask.Wait();

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error.");

            return View("Index");
        }
    }
}
