using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactBook.Web.Models.Class
{
    public class ViewStudentByClassId
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string DayOfBirth { get; set; }

        public string PhoneNumber { get; set; }
    }
}
