using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebContactBook.Web.ModelsStudent;
using WebContactBook.Web.Ultilities;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        [Route("/Student/StudentDetails/{id}")]
        public IActionResult StudentDetails(int id)
        {
            var result = new ViewStudent();
            result = ApiHelper<ViewStudent>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api//api/student/get/{id}"
                                                );
            return Json(new { result });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
