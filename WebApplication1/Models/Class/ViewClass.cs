using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactBook.Web.Models.Class
{
    public class ViewClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int GradeId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }
        public int Students { get; set; }
    }
}
