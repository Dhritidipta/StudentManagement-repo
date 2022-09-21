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

namespace StudentManagement.WebApp.Controllers
{
    public class StudentController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly string BaseUrl = "https://localhost:5001/api/";

        public IActionResult Details(int id)
        {

            Student student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync($"students/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    student = JsonConvert.DeserializeObject<Student>(response.Content.ReadAsStringAsync().Result);
                }
            }


            return View(student);
        }

        public IActionResult Create()
        {
            var courses = GetDetailsUtility.GetCoursesList();

            List<SelectListItem> courseList = new List<SelectListItem>();
            foreach (var item in courses)
            {

                courseList.Add(new SelectListItem { Value = item.CourseId.ToString() , Text = item.CourseName });
            }

            var sections = GetDetailsUtility.GetSectionsList(); ;

            List<SelectListItem> sectionList = new List<SelectListItem>();
            foreach (var item in sections)
            {

                sectionList.Add(new SelectListItem { Value = item.SectionId.ToString(), Text = item.SectionName });
            }

            //assigning SelectListItem to view Bag
            ViewBag.courses = courseList;
            ViewBag.sections = sectionList;
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
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error.");

            return View(student);
        }

        public ViewResult Edit(int id)
        {
            var courses = GetDetailsUtility.GetCoursesList();

            List<SelectListItem> courseList = new List<SelectListItem>();
            foreach (var item in courses)
            {

                courseList.Add(new SelectListItem { Value = item.CourseName, Text = item.CourseName });
            }

            var sections = GetDetailsUtility.GetSectionsList(); ;

            List<SelectListItem> sectionList = new List<SelectListItem>();
            foreach (var item in sections)
            {

                sectionList.Add(new SelectListItem { Value = item.SectionName, Text = item.SectionName });
            }

            Student student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync($"students/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    student = JsonConvert.DeserializeObject<Student>(response.Content.ReadAsStringAsync().Result);
                }
            }
            //assigning SelectListItem to view Bag
            ViewBag.courses = courseList;
            ViewBag.sections = sectionList;

            ViewBag.id = id;
            ViewBag.student = student;
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
                    return RedirectToAction("Index", "Home");
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
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error.");
            //return View("Index");
            return RedirectToAction("Index", "Home");

        }
    }
}
