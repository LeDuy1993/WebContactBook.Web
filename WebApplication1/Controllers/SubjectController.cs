using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactBook.Web.Models.Subject;
using WebContactBook.Web.Ultilities;

namespace WebContactBook.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ILogger<SubjectController> logger)
        {
            _logger = logger;
        }
        [Route("/Subject/GetSubjectByClassId/{classId}")]
        public JsonResult GetSubjectByClassId(int classId)
        {
            var subjects = new List<GetSubjectByClassId>();
            subjects = ApiHelper<List<GetSubjectByClassId>>.HttpGetAsync($"{Helper.ApiUrl}api/subject/getSubjectByClassId/{classId}");
            return Json(new { subjects });
        }
        [Route("/Subject/GetSubjectAll")]
        public JsonResult GetSubjectAll()
        {
            var subjects = new List<GetSubjectAll>();
            subjects = ApiHelper<List<GetSubjectAll>>.HttpGetAsync($"{Helper.ApiUrl}api/subject/getSubjectAll");
            return Json(new { subjects });
        }

    }
}
