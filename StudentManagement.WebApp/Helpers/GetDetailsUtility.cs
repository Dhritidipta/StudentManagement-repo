using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StudentManagement.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Helpers
{
    public static class GetDetailsUtility
    {
        private static readonly string BaseUrl = "https://localhost:5001/api/";

        public static IEnumerable<Course> GetCoursesList()
        {
            IEnumerable<Course> courses = new List<Course>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("courses").Result;

                if (response.IsSuccessStatusCode)
                {
                    courses = JsonConvert.DeserializeObject<IList<Course>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            return courses;
        }
        
        public static IEnumerable<Section> GetSectionsList()
        {
            IEnumerable<Section> sections = new List<Section>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("sections").Result;

                if (response.IsSuccessStatusCode)
                {
                    sections = JsonConvert.DeserializeObject<IList<Section>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            return sections;
        }
    }
}
