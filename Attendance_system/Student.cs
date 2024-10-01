using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_S
{
    public class Student
    {
    
        public int StudentId { get; set; }
        public string S_Name { get; set; }
        public string S_Username { get; set; }
        public string S_Password { get; set; }
        public UserType Type { get; set; }
        public IEnumerable<CourseStudent>? Courses { get; set; }
    }
}