using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactBook.Web.Models.Course;
using WebContactBook.Web.Models.Grade;
using WebContactBook.Web.Ultilities;

namespace WebContactBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Contact book";
            return View();
        }
        public JsonResult GetAllGrades()
        {
            var grades = new List<ViewGrade>();
            grades = ApiHelper<List<ViewGrade>>.HttpGetAsync($"{Helper.ApiUrl}api/grade/gets");
            return Json(new { grades });
        }
        public JsonResult GetAllCourses()
        {
            var courses = new List<ViewCourse>();
            courses = ApiHelper<List<ViewCourse>>.HttpGetAsync($"{Helper.ApiUrl}api/course/gets");
            return Json(new { courses });
        }
    }

}
