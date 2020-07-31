using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactBook.Web.Models.Class;
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
        /// <summary>
        /// Lọc dữ liệu trên SQL
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        [Route("/Home/GetsByCourseIdAndGradeId/{courseId}/{gradeId}")]
        public JsonResult GetsByCourseIdAndGradeId(int courseId =0, int gradeId=0)
        {
            var classRooms = new List<ViewClass>();
            classRooms = ApiHelper<List<ViewClass>>.HttpGetAsync($"{Helper.ApiUrl}api/classRoom/getsByCourseIdAndGradeId/{courseId},{gradeId}");
            return Json(new { classRooms });
        }

        //Sử lý lọc trên C# 
        /* [Route("/Home/Search/{courseId}/{gradeId}")]
         public JsonResult GetAllClass(int courseId = 0, int gradeId = 0)
         {
             var classRooms = new List<ViewClass>();
             classRooms = ApiHelper<List<ViewClass>>.HttpGetAsync($"{Helper.ApiUrl}api/classRoom/gets");
             if(courseId != 0 && gradeId != 0)
             {
                 classRooms = (from e in classRooms
                               where e.CourseId == courseId && e.GradeId == gradeId
                               select e).ToList();
                 //classRooms.Where(e => e.CourseId == courseId && e.GradeId == gradeId).Select(e => e);
             }
             else
             {
                 if(courseId != 0)
                 {
                     classRooms = (from e in classRooms
                                   where e.CourseId == courseId
                                   select e).ToList();
                     //classRooms.Where(e => e.CourseId == courseId).Select(e => e);
                 }
             }
             return Json(new { classRooms });
         }*/
        public JsonResult GetAllClass()
        {
            var classRooms = new List<ViewClass>();
            classRooms = ApiHelper<List<ViewClass>>.HttpGetAsync($"{Helper.ApiUrl}api/classRoom/gets");
            return Json(new { classRooms });
        }
    }

}
