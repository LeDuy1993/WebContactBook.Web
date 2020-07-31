using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactBook.Web.Models.Point;
using WebContactBook.Web.Ultilities;

namespace WebContactBook.Web.Controllers
{
    public class PointController : Controller
    {
        private readonly ILogger<PointController> _logger;

        public PointController(ILogger<PointController> logger)
        {
            _logger = logger;
        }
        [Route("/Point/GetSubjectAll")]
        public JsonResult GetTypePointAll()
        {
            var typePointAlls = new List<GetTypePointAll>();
            typePointAlls = ApiHelper<List<GetTypePointAll>>.HttpGetAsync($"{Helper.ApiUrl}api/point/getTypePointAll");
            return Json(new { typePointAlls });
        }
    }
}
