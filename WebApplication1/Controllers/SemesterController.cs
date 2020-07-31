using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactBook.Web.Models.Semester;
using WebContactBook.Web.Ultilities;

namespace WebContactBook.Web.Controllers
{
    public class SemesterController : Controller
    {
        private readonly ILogger<SemesterController> _logger;

        public SemesterController(ILogger<SemesterController> logger)
        {
            _logger = logger;
        }
        [Route("/Semester/GetSemesterAll")]
        public JsonResult GetSemesterAll()
        {
            var semesterAlls = new List<GetSemesterAll>();
            semesterAlls = ApiHelper<List<GetSemesterAll>>.HttpGetAsync($"{Helper.ApiUrl}api/semsester/getSemesterAll");
            return Json(new { semesterAlls });
        }
    }
}
